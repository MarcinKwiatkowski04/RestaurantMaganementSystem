using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KitchenButton_Click(object sender, RoutedEventArgs e)
        {
            KitchenWindow kw = new KitchenWindow();
            kw.Show();
            this.Close();
        }

        private void DeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveryWindow dw = new DeliveryWindow();
            dw.Show();
            this.Close();
        }

        private void AdministrationButton_Click(object sender, RoutedEventArgs e)
        {
            AdministrationLoginWindow alw = new AdministrationLoginWindow();
            alw.Show();
            this.Close();
        }

        private void getOrder_Click(object sender, RoutedEventArgs e)
        {
            GetOrderWindow gow = new GetOrderWindow();
            gow.Show();
            this.Close();
        }
    }
}
