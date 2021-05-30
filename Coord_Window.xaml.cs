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
    /// Interaction logic for Coord_Window.xaml
    /// </summary>
    public partial class Coord_Window : Window
    {
        protected asdfg_v2.airportDataSet airportDataSet;
        protected asdfg_v2.airportDataSetTableAdapters.ЭкипажиTableAdapter airportDataSetЭкипажиTableAdapter;
        protected asdfg_v2.airportDataSetTableAdapters.FlightsTableAdapter airportDataSetFlightsTableAdapter;
        protected asdfg_v2.airportDataSetTableAdapters.СамолетыTableAdapter airportDataSetСамолетыTableAdapter;
        protected asdfg_v2.airportDataSetTableAdapters.TicketsTableAdapter airportDataSetTicketsTableAdapter;

        public Coord_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            airportDataSet = ((asdfg_v2.airportDataSet)(this.FindResource("airportDataSet")));

            // Load data into the table Экипажи. You can modify this code as needed.
            airportDataSetЭкипажиTableAdapter = new asdfg_v2.airportDataSetTableAdapters.ЭкипажиTableAdapter();
            airportDataSetЭкипажиTableAdapter.Fill(airportDataSet.Экипажи);
            System.Windows.Data.CollectionViewSource экипажиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("экипажиViewSource")));
            экипажиViewSource.View.MoveCurrentToFirst();

            // Load data into the table Flights. You can modify this code as needed.
            airportDataSetFlightsTableAdapter = new asdfg_v2.airportDataSetTableAdapters.FlightsTableAdapter();
            airportDataSetFlightsTableAdapter.Fill(airportDataSet.Flights);
            System.Windows.Data.CollectionViewSource flightsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("flightsViewSource")));
            flightsViewSource.View.MoveCurrentToFirst();

            // Load data into the table Самолеты. You can modify this code as needed.
            airportDataSetСамолетыTableAdapter = new asdfg_v2.airportDataSetTableAdapters.СамолетыTableAdapter();
            airportDataSetСамолетыTableAdapter.Fill(airportDataSet.Самолеты);
            System.Windows.Data.CollectionViewSource самолетыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("самолетыViewSource")));
            самолетыViewSource.View.MoveCurrentToFirst();

            // Load data into the table Рейсы. You can modify this code as needed.
            asdfg_v2.airportDataSetTableAdapters.РейсыTableAdapter airportDataSetРейсыTableAdapter = new asdfg_v2.airportDataSetTableAdapters.РейсыTableAdapter();
            airportDataSetРейсыTableAdapter.Fill(airportDataSet.Рейсы);
            System.Windows.Data.CollectionViewSource рейсыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("рейсыViewSource")));
            рейсыViewSource.View.MoveCurrentToFirst();

            // Load data into the table Tickets. You can modify this code as needed.
            airportDataSetTicketsTableAdapter = new asdfg_v2.airportDataSetTableAdapters.TicketsTableAdapter();
            airportDataSetTicketsTableAdapter.Fill(airportDataSet.Tickets);
            System.Windows.Data.CollectionViewSource ticketsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ticketsViewSource")));
            ticketsViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            this.airportDataSetFlightsTableAdapter.Update(airportDataSet);
            this.airportDataSetTicketsTableAdapter.Update(airportDataSet);
            this.airportDataSetСамолетыTableAdapter.Adapter.Update(airportDataSet);
            this.airportDataSetЭкипажиTableAdapter.Adapter.Update(airportDataSet);
        }
    }
}
