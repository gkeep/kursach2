using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace asdfg_v2
{
    /// <summary>
    /// Interaction logic for Engineer_Window.xaml
    /// </summary>
    public partial class Engineer_Window : Window
    {
        private string ConnectionString = "Data Source=.; Initial Catalog=airport; Integrated Security=True";
        private DataTable mainTable = new DataTable();

        public Engineer_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = @"
                        SELECT dbo.Planes.plane_name AS Самолет, 
                            dbo.Plane_types.plane_type_name AS Тип, 
                            dbo.Employees.employee_name AS Механик, 
                            dbo.Planes.last_repair AS [Последнее обслуживание]
                        FROM dbo.Planes INNER JOIN
                            dbo.Plane_types ON dbo.Planes.plane_type_ID = dbo.Plane_types.ID_type INNER JOIN
                            dbo.Employees ON dbo.Planes.employee_ID = dbo.Employees.ID_employee"
                };

                connection.Open();

                var reader = command.ExecuteReader();

                for (int i = 0; i <= 3; i++)
                {
                    mainTable.Columns.Add(reader.GetName(i));
                }

                while (reader.Read())
                {
                    var date = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    mainTable.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), date);
                }

                reader.Close();
                connection.Close();

                var bindingSource = new BindingSource();
                bindingSource.DataSource = mainTable;

                dataGrid.ItemsSource = bindingSource;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable planeDT = mainTable.Copy();
            planeDT.Columns.RemoveAt(1);
            planeDT.Columns.RemoveAt(1);

            foreach (DataColumn column in planeDT.Columns)
            {
                Console.WriteLine("1: " + column.ColumnName);
            }

            DataTable empDT = mainTable.Copy();
            empDT.Columns.RemoveAt(0);
            empDT.Columns.RemoveAt(0);
            empDT.Columns.RemoveAt(1);

            DataTable planeTypesDT = mainTable.Copy();
            planeTypesDT.Columns.RemoveAt(0);
            planeTypesDT.Columns.RemoveAt(1);
            planeTypesDT.Columns.RemoveAt(1);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlBulkCopy bulkCopyPlanes = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopyPlanes.DestinationTableName = "Planes";
                    bulkCopyPlanes.ColumnMappings.Add(planeDT.Columns[0].ColumnName.ToString(), "plane_name");
                    bulkCopyPlanes.ColumnMappings.Add(planeDT.Columns[1].ColumnName.ToString(), "last_repair");
                    bulkCopyPlanes.WriteToServer(planeDT);

                    SqlBulkCopy bulkCopyEmp = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopyEmp.DestinationTableName = "Employees";
                    bulkCopyEmp.ColumnMappings.Add(empDT.Columns[0].ColumnName.ToString(), "employee_name");
                    bulkCopyEmp.WriteToServer(empDT);

                    SqlBulkCopy bulkCopyTypes = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopyTypes.DestinationTableName = "Plane_types";
                    bulkCopyTypes.ColumnMappings.Add(planeTypesDT.Columns[0].ColumnName.ToString(), "plane_type_name");
                    bulkCopyTypes.WriteToServer(planeTypesDT);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ERROR] Couldn't save changes to DB: " + ex);
                }

                connection.Close();
            }
        }
    }
}
