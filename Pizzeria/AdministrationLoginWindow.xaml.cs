using System.Data.SqlClient;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for AdministrationLoginWindow.xaml
    /// </summary>
    public partial class AdministrationLoginWindow : Window
    {

        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public AdministrationLoginWindow()
        {
            InitializeComponent();
        }

       // const string password = "Italiana";
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            string queryGetPassword = "SELECT Haslo FROM ADMINISTRACJA";
            SqlCommand cmdGetPassword = new SqlCommand(queryGetPassword, connection);
            string password = cmdGetPassword.ExecuteScalar().ToString().Trim();

            if (passwordTxtbox.Text == password)
            {
                AdministrationWindow aw = new AdministrationWindow();
                aw.Show();
                this.Close();
            }
            else MessageBox.Show("Nieprawidłowe hasło!");
            connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
