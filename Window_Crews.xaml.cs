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

namespace asdfg_v2
{
    /// <summary>
    /// Interaction logic for Window_Crews.xaml
    /// </summary>
    public partial class Window_Crews : Window
    {
        public Window_Crews()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            asdfg_v2.airportDataSet airportDataSet = ((asdfg_v2.airportDataSet)(this.FindResource("airportDataSet")));
            // Load data into the table View_Crews. You can modify this code as needed.
            asdfg_v2.airportDataSetTableAdapters.View_CrewsTableAdapter airportDataSetView_CrewsTableAdapter = new asdfg_v2.airportDataSetTableAdapters.View_CrewsTableAdapter();
            airportDataSetView_CrewsTableAdapter.Fill(airportDataSet.View_Crews);
            System.Windows.Data.CollectionViewSource view_CrewsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("view_CrewsViewSource")));
            view_CrewsViewSource.View.MoveCurrentToFirst();
            // Load data into the table Рейсы. You can modify this code as needed.
            asdfg_v2.airportDataSetTableAdapters.РейсыTableAdapter airportDataSetРейсыTableAdapter = new asdfg_v2.airportDataSetTableAdapters.РейсыTableAdapter();
            airportDataSetРейсыTableAdapter.Fill(airportDataSet.Рейсы);
            System.Windows.Data.CollectionViewSource рейсыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("рейсыViewSource")));
            рейсыViewSource.View.MoveCurrentToFirst();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
