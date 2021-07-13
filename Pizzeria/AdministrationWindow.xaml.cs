using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public AdministrationWindow()
        {
            InitializeComponent();
            FillDataGrid();
            FillBudget();

        }
        public void FillBudget()
        {
            connection.Open();

            double budget = 0.00;

            budgetLabel.Content = "AKTUALNY BUDŻET: ";

            string queryGetBudget = "SELECT Budzet FROM Administracja";
            SqlCommand cmdGetBudget = new SqlCommand(queryGetBudget, connection);
            budget = Double.Parse(cmdGetBudget.ExecuteScalar().ToString());
            //budget.ToString("#.##");

            budgetLabel.Content += Environment.NewLine + budget + " zł." ;

            connection.Close();
        }

        public void FillDataGrid()
        {
            connection.Open();

            string queryGetEmployees = "SELECT * FROM Pracownicy";
            SqlCommand cmdGE = new SqlCommand(queryGetEmployees, connection);
            cmdGE.ExecuteScalar();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdGE);
            DataTable dt = new DataTable("Pracownicy");
            dataAdapter.Fill(dt);
            WorkersDataGrid.ItemsSource = dt.DefaultView;
            dataAdapter.Update(dt);

            connection.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void issuePayrollsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz wysłać wypłaty?", "Potwierdzenie", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    issuePayrolls();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        public void issuePayrolls()
        {
            connection.Open();

            double totalPayrolls = 0.00;
            double budget = 0.00;
            double newBudget = 0.00;

            string queryGetTotalPayrolls = "SELECT SUM(KwotaWyplaty) FROM PRACOWNICY";
            SqlCommand cmdTotalPayrolls = new SqlCommand(queryGetTotalPayrolls, connection);
            totalPayrolls = Double.Parse(cmdTotalPayrolls.ExecuteScalar().ToString());

            string queryGetBudget = "SELECT Budzet FROM Administracja";
            SqlCommand cmdGetBudget = new SqlCommand(queryGetBudget, connection);
            budget = Double.Parse(cmdGetBudget.ExecuteScalar().ToString());

            newBudget = budget - totalPayrolls;
            //newBudget.ToString().Replace(",", ".");
            

            if (newBudget >= 0)
            {
                string queryUpdateBudget = "update Administracja set Budzet=" + newBudget.ToString().Replace(",", ".");
                SqlCommand cmdUpdateBudget = new SqlCommand(queryUpdateBudget, connection);
                cmdUpdateBudget.ExecuteScalar();
                MessageBox.Show("Wysłano wypłaty", "Potwierdzenie");
                connection.Close();
                FillBudget();
            }
            else MessageBox.Show("Brak środków", "Błąd");


            connection.Close();
        }
    }
}
