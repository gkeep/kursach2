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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace asdfg_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = textBox_Name.Text;
            var password = passwordBox.Password;
            var position = "";

            SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=airport; Integrated Security=True");

            string getPassword = $"select _password, position from Logins where _login = '{username}'";

            SqlDataAdapter adapter = new SqlDataAdapter(getPassword, connection);
            DataTable dt = new DataTable();

            connection.Open();
            try
            {
                adapter.Fill(dt);
                string pass = dt.Rows[0][0].ToString();

                if (pass == password)
                {
                    position = dt.Rows[0][1].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Incorrect username or password");
                textBox_Name.Foreground = new SolidColorBrush(Colors.Red);
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
            }
            connection.Close();

            var crewsWindow = new Window_Crews();

            switch (position)
            {
                case "Бортпроводник":
                    crewsWindow.Show();
                    Console.WriteLine($"Launched {position} form");
                    break;
                case "Пилот":
                    crewsWindow.Show();
                    Console.WriteLine($"Launched {position} form");
                    break;
                case "Инженер":
                    var engineerWindow = new Engineer_Window();
                    engineerWindow.Show();
                    Console.WriteLine($"Launched {position} form");
                    break;
                case "Координатор":
                    var coordWindow = new Coord_Window();
                    coordWindow.Show();
                    Console.WriteLine($"Launched {position} form");
                    break;
                default:
                    Console.WriteLine("Unknown position, no form launched");
                    break;
            }
        }
    }
}