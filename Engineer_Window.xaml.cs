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
                    CommandText = @"SELECT * FROM [Самолеты]"
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
            //foreach (DataRow row in mainTable.Rows)
            //{
            //    Console.WriteLine(row.ItemArray[0].ToString());
            //}

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // TODO: Do not use View or find another way to update the DB
                // View or function 'Самолеты' is not updatable because the modification affects multiple base tables.
                connection.Open();
                try
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopy.DestinationTableName = "[Самолеты]";
                    bulkCopy.WriteToServer(mainTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ERROR] Couldn't save changes to SQL DB");
                }

                connection.Close();
            }
        }
    }
}
