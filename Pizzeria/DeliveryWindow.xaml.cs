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
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {

        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public DeliveryWindow()
        {
            InitializeComponent();
            FillLeftLabels();
            FillRightLabels();
        }

        public void ShowLabels()
        {
            //select Miasto FROM Adresy a join Zamowienia z on a.Id= z.IdAdresu where z.Status=1 order by SYSDATETIME();
        }



        private void BackKitchenButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        public void FillLeftLabels()
        {
            connection.Open();


            string queryCheckNextOrder = "select count(Id) FROM Zamowienia where Status=1; ";
            SqlCommand cmdCheckNextOrder = new SqlCommand(queryCheckNextOrder, connection);
            int orderCounter = Int32.Parse(cmdCheckNextOrder.ExecuteScalar().ToString());

            if (orderCounter > 0)
            {

                string queryGetOrderId = "select top 1 Id FROM Zamowienia where Status=1 order by SYSDATETIME(); ";
                SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
                int orderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

                string queryGetAddress = "select top 1 IdAdresu FROM Zamowienia where Status=1 order by SYSDATETIME(); ";
                SqlCommand cmdGetAddress = new SqlCommand(queryGetAddress, connection);
                int addressId = Int32.Parse(cmdGetAddress.ExecuteScalar().ToString());


                string queryGetCity = "select Miasto FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetCity = new SqlCommand(queryGetCity, connection);
                city1Label.Content = cmdGetCity.ExecuteScalar().ToString();

                string queryGetStreet = "select Ulica FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetStreet = new SqlCommand(queryGetStreet, connection);
                street1Label.Content = cmdGetStreet.ExecuteScalar().ToString();

                string queryGetBuildingNumber = "select NrBudynku FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetBuildingNumber = new SqlCommand(queryGetBuildingNumber, connection);
                number1Label.Content = cmdGetBuildingNumber.ExecuteScalar().ToString().Trim();

                string queryGetLocalNumber = "select NrMieszkania FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetLocalNumber = new SqlCommand(queryGetLocalNumber, connection);
                number1Label.Content += " / " + cmdGetLocalNumber.ExecuteScalar().ToString();

                string queryGetAmount = "select Kwota FROM Zamowienia where Id = " + orderId;
                SqlCommand cmdGetAmount = new SqlCommand(queryGetAmount, connection);
                amount1Label.Content = cmdGetAmount.ExecuteScalar().ToString();

                string queryGetPaymentMethod = "select MetodaPlatnosci FROM Zamowienia where Id = " + orderId;
                SqlCommand cmdGetPaymentMethod = new SqlCommand(queryGetPaymentMethod, connection);
                int paymentMethod = Int32.Parse(cmdGetPaymentMethod.ExecuteScalar().ToString());
                if (paymentMethod == 0) method1Label.Content = "KARTA";
                else if (paymentMethod == 1) method1Label.Content = "GOTÓWKA";

                //USTAWIENIE LICZNIKA ILOSCI PIZZ DLA ZAMOWIENIA
                int counter = CheckPizzaQuantity();

                if (counter >= 1)
                {
                    string queryGetOrder1 = "SELECT top 1 Pizza1Id FROM Zamowienia where status=1 order by SYSDATETIME() ";
                    SqlCommand cmdGetOrder1 = new SqlCommand(queryGetOrder1, connection);
                    int pizza1Id = Int32.Parse(cmdGetOrder1.ExecuteScalar().ToString());

                    //Przetłumaczenie ID pizz na nazwy do wklejenia ich do zamówienia
                    string queryGetPizza1 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza1Id where z.Pizza1Id = " + pizza1Id;
                    SqlCommand cmdGetPizzaName1 = new SqlCommand(queryGetPizza1, connection);
                    cmdGetPizzaName1.ExecuteScalar();
                    string pizza1Name = cmdGetPizzaName1.ExecuteScalar().ToString();
                    pizza11Label.Content = pizza1Name;
                }
                if (counter >= 2)
                {
                    string queryGetOrder2 = "SELECT top 1 Pizza2Id FROM Zamowienia where status=1 order by SYSDATETIME() ";
                    SqlCommand cmdGetOrder2 = new SqlCommand(queryGetOrder2, connection);
                    cmdGetOrder2.ExecuteScalar();
                    int pizza2Id = Int32.Parse(cmdGetOrder2.ExecuteScalar().ToString());

                    string queryGetPizza2 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza2Id where z.Pizza2Id = " + pizza2Id;
                    SqlCommand cmdGetPizzaName2 = new SqlCommand(queryGetPizza2, connection);
                    cmdGetPizzaName2.ExecuteScalar();
                    string pizza2Name = cmdGetPizzaName2.ExecuteScalar().ToString();
                    pizza12Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza12Label.Background = Brushes.White;
                    pizza12Label.Content = pizza2Name;
                }
                if (counter >= 3)
                {
                    string queryGetOrder3 = "SELECT top 1 Pizza3Id FROM Zamowienia where status=1 order by SYSDATETIME() ";
                    SqlCommand cmdGetOrder3 = new SqlCommand(queryGetOrder3, connection);
                    cmdGetOrder3.ExecuteScalar();
                    int pizza3Id = Int32.Parse(cmdGetOrder3.ExecuteScalar().ToString());

                    string queryGetPizza3 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza3Id where z.Pizza3Id = " + pizza3Id;
                    SqlCommand cmdGetPizzaName3 = new SqlCommand(queryGetPizza3, connection);
                    cmdGetPizzaName3.ExecuteScalar();
                    string pizza3Name = cmdGetPizzaName3.ExecuteScalar().ToString();
                    pizza13Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza13Label.Background = Brushes.White;
                    pizza13Label.Content = pizza3Name;
                }
                if (counter >= 4)
                {
                    string queryGetOrder4 = "SELECT top 1 Pizza4Id FROM Zamowienia where status=1 order by SYSDATETIME() ";
                    SqlCommand cmdGetOrder4 = new SqlCommand(queryGetOrder4, connection);
                    cmdGetOrder4.ExecuteScalar();
                    int pizza4Id = Int32.Parse(cmdGetOrder4.ExecuteScalar().ToString());

                    string queryGetPizza4 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza4Id where z.Pizza4Id = " + pizza4Id;
                    SqlCommand cmdGetPizzaName4 = new SqlCommand(queryGetPizza4, connection);
                    cmdGetPizzaName4.ExecuteScalar();
                    string pizza4Name = cmdGetPizzaName4.ExecuteScalar().ToString();
                    pizza14Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza14Label.Background = Brushes.White;
                    pizza14Label.Content = pizza4Name;
                }
                if (counter >= 5)
                {
                    string queryGetOrder5 = "SELECT top 1 Pizza5Id FROM Zamowienia where status=1 order by SYSDATETIME() ";
                    SqlCommand cmdGetOrder5 = new SqlCommand(queryGetOrder5, connection);
                    cmdGetOrder5.ExecuteScalar();
                    int pizza5Id = Int32.Parse(cmdGetOrder5.ExecuteScalar().ToString());

                    string queryGetPizza5 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza5Id where z.Pizza5Id = " + pizza5Id;
                    SqlCommand cmdGetPizzaName5 = new SqlCommand(queryGetPizza5, connection);
                    cmdGetPizzaName5.ExecuteScalar();
                    string pizza5Name = cmdGetPizzaName5.ExecuteScalar().ToString();
                    pizza15Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza15Label.Background = Brushes.White;
                    pizza15Label.Content = pizza5Name;
                }
            } else if (orderCounter==0)
            {
                city1Label.Content = "";
                method1Label.Content = "";
                street1Label.Content = "";
                number1Label.Content = "";
                amount1Label.Content = "";
                pizza11Label.Content = "";
                pizza12Label.Content = "";
                pizza13Label.Content = "";
                pizza14Label.Content = "";
                pizza15Label.Content = "";
            }

            connection.Close();
        }


        public void FillRightLabels()
        {
            connection.Open();

            string queryCheckNextOrder = "select count(Id) FROM Zamowienia where Status=1; ";
            SqlCommand cmdCheckNextOrder = new SqlCommand(queryCheckNextOrder, connection);
            int orderCounter = Int32.Parse(cmdCheckNextOrder.ExecuteScalar().ToString());

            if (orderCounter > 1)
            {
                //string queryGetOrderId = "select top 1 Id FROM Zamowienia where Status=1 order by SYSDATETIME(); ";
                string queryGetOrderId = "SELECT top 1 Id FROM(SELECT TOP 2 * FROM Zamowienia where status = 1  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
                int orderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

                string queryGetAddress = "select top 1 IdAdresu FROM Zamowienia where Id = " + orderId;
                SqlCommand cmdGetAddress = new SqlCommand(queryGetAddress, connection);
                int addressId = Int32.Parse(cmdGetAddress.ExecuteScalar().ToString());


                string queryGetCity = "select Miasto FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetCity = new SqlCommand(queryGetCity, connection);
                city2Label.Content = cmdGetCity.ExecuteScalar().ToString();

                string queryGetStreet = "select Ulica FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetStreet = new SqlCommand(queryGetStreet, connection);
                street2Label.Content = cmdGetStreet.ExecuteScalar().ToString();

                string queryGetBuildingNumber = "select NrBudynku FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetBuildingNumber = new SqlCommand(queryGetBuildingNumber, connection);
                number2Label.Content = cmdGetBuildingNumber.ExecuteScalar().ToString().Trim();

                string queryGetLocalNumber = "select NrMieszkania FROM Adresy where Id = " + addressId;
                SqlCommand cmdGetLocalNumber = new SqlCommand(queryGetLocalNumber, connection);
                number2Label.Content += " / " + cmdGetLocalNumber.ExecuteScalar().ToString();

                string queryGetAmount = "select Kwota FROM Zamowienia where Id = " + orderId;
                SqlCommand cmdGetAmount = new SqlCommand(queryGetAmount, connection);
                amount2Label.Content = cmdGetAmount.ExecuteScalar().ToString();

                string queryGetPaymentMethod = "select MetodaPlatnosci FROM Zamowienia where Id = " + orderId;
                SqlCommand cmdGetPaymentMethod = new SqlCommand(queryGetPaymentMethod, connection);
                int paymentMethod = Int32.Parse(cmdGetPaymentMethod.ExecuteScalar().ToString());
                if (paymentMethod == 0) method2Label.Content = "KARTA";
                else if (paymentMethod == 1) method2Label.Content = "GOTÓWKA";

                //USTAWIENIE LICZNIKA ILOSCI PIZZ DLA ZAMOWIENIA
                int counter = CheckPizzaQuantity2();

                if (counter >= 1)
                {
                    string queryGetOrder1 = "SELECT top 1 Pizza1Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=1  ORDER BY ID) a ORDER BY ID DESC ";
                    SqlCommand cmdGetOrder1 = new SqlCommand(queryGetOrder1, connection);
                    int pizza1Id = Int32.Parse(cmdGetOrder1.ExecuteScalar().ToString());

                    //Przetłumaczenie ID pizz na nazwy do wklejenia ich do zamówienia
                    string queryGetPizza1 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza1Id where z.Pizza1Id = " + pizza1Id;
                    SqlCommand cmdGetPizzaName1 = new SqlCommand(queryGetPizza1, connection);
                    cmdGetPizzaName1.ExecuteScalar();
                    string pizza1Name = cmdGetPizzaName1.ExecuteScalar().ToString();
                    pizza21Label.Content = pizza1Name;
                }
                if (counter >= 2)
                {
                    string queryGetOrder2 = "SELECT top 1 Pizza2Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=1  ORDER BY ID) a ORDER BY ID DESC ";
                    SqlCommand cmdGetOrder2 = new SqlCommand(queryGetOrder2, connection);
                    cmdGetOrder2.ExecuteScalar();
                    int pizza2Id = Int32.Parse(cmdGetOrder2.ExecuteScalar().ToString());

                    string queryGetPizza2 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza2Id where z.Pizza2Id = " + pizza2Id;
                    SqlCommand cmdGetPizzaName2 = new SqlCommand(queryGetPizza2, connection);
                    cmdGetPizzaName2.ExecuteScalar();
                    string pizza2Name = cmdGetPizzaName2.ExecuteScalar().ToString();
                    pizza22Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza22Label.Background = Brushes.White;
                    pizza22Label.Content = pizza2Name;
                }
                if (counter >= 3)
                {
                    string queryGetOrder3 = "SELECT top 1 Pizza3Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=1  ORDER BY ID) a ORDER BY ID DESC ";
                    SqlCommand cmdGetOrder3 = new SqlCommand(queryGetOrder3, connection);
                    cmdGetOrder3.ExecuteScalar();
                    int pizza3Id = Int32.Parse(cmdGetOrder3.ExecuteScalar().ToString());

                    string queryGetPizza3 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza3Id where z.Pizza3Id = " + pizza3Id;
                    SqlCommand cmdGetPizzaName3 = new SqlCommand(queryGetPizza3, connection);
                    cmdGetPizzaName3.ExecuteScalar();
                    string pizza3Name = cmdGetPizzaName3.ExecuteScalar().ToString();
                    pizza23Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza23Label.Background = Brushes.White;
                    pizza23Label.Content = pizza3Name;
                }
                if (counter >= 4)
                {
                    string queryGetOrder4 = "SELECT top 1 Pizza4Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=1  ORDER BY ID) a ORDER BY ID DESC ";
                    SqlCommand cmdGetOrder4 = new SqlCommand(queryGetOrder4, connection);
                    cmdGetOrder4.ExecuteScalar();
                    int pizza4Id = Int32.Parse(cmdGetOrder4.ExecuteScalar().ToString());

                    string queryGetPizza4 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza4Id where z.Pizza4Id = " + pizza4Id;
                    SqlCommand cmdGetPizzaName4 = new SqlCommand(queryGetPizza4, connection);
                    cmdGetPizzaName4.ExecuteScalar();
                    string pizza4Name = cmdGetPizzaName4.ExecuteScalar().ToString();
                    pizza24Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza24Label.Background = Brushes.White;
                    pizza24Label.Content = pizza4Name;
                }
                if (counter >= 5)
                {
                    string queryGetOrder5 = "SELECT top 1 Pizza5Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=1  ORDER BY ID) a ORDER BY ID DESC ";
                    SqlCommand cmdGetOrder5 = new SqlCommand(queryGetOrder5, connection);
                    cmdGetOrder5.ExecuteScalar();
                    int pizza5Id = Int32.Parse(cmdGetOrder5.ExecuteScalar().ToString());

                    string queryGetPizza5 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza5Id where z.Pizza5Id = " + pizza5Id;
                    SqlCommand cmdGetPizzaName5 = new SqlCommand(queryGetPizza5, connection);
                    cmdGetPizzaName5.ExecuteScalar();
                    string pizza5Name = cmdGetPizzaName5.ExecuteScalar().ToString();
                    pizza25Label.BorderThickness = new Thickness(1, 1, 1, 1);
                    pizza25Label.Background = Brushes.White;
                    pizza25Label.Content = pizza5Name;
                } else if (orderCounter <2)
                {
                    city2Label.Content = "";
                    method2Label.Content = "";
                    street2Label.Content = "";
                    number2Label.Content = "";
                    amount2Label.Content = "";
                    pizza21Label.Content = "";
                    pizza22Label.Content = "";
                    pizza23Label.Content = "";
                    pizza24Label.Content = "";
                    pizza25Label.Content = "";
                }
            }
            connection.Close();
        }

        public int CheckPizzaQuantity()
        {
            int quantity = 0;


            string queryGetOrderId = "select top 1 Id FROM Zamowienia where Status=1 order by SYSDATETIME(); ";
            SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
            int oldestOrderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

            string queryCounter = "SELECT Pizza1Id from Zamowienia where Id = " + oldestOrderId;
            SqlCommand cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza2Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza3Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza4Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza5Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            return quantity;
        }

        public int CheckPizzaQuantity2()
        {
            int quantity = 0;


            string queryGetOrderId = "SELECT top 1 Id FROM (SELECT TOP 2 * FROM Zamowienia where status=1 ORDER BY ID ASC) a order by ID DESC";

            SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
            int oldestOrderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

            string queryCounter = "SELECT Pizza1Id from Zamowienia where Id = " + oldestOrderId;
            SqlCommand cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza2Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza3Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza4Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Pizza5Id from Zamowienia where Id = " + oldestOrderId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            return quantity;
        }

        
        private void UpdateLeftOrder()
        {
            connection.Open();

            string queryGetOrderId = "select top 1 Id FROM Zamowienia where Status=1 order by SYSDATETIME(); ";
            SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
            int orderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

            string queryUpdateOrder = "update Zamowienia set status=2, DataZamowienia=GETDATE() where id= " + orderId;
            SqlCommand cmdUpdateOrder = new SqlCommand(queryUpdateOrder, connection);
            cmdUpdateOrder.ExecuteScalar();

            AddAmount1ToBudget();

            connection.Close();
            FillLeftLabels();
            FillRightLabels();
        }

        private void UpdateRightOrder()
        {
            connection.Open();
            
            string queryGetOrderId = "SELECT top 1 Id FROM (SELECT TOP 2 * FROM Zamowienia where status=1 ORDER BY ID ASC) a order by ID DESC";
            SqlCommand cmdGetOrderId = new SqlCommand(queryGetOrderId, connection);
            int orderId = Int32.Parse(cmdGetOrderId.ExecuteScalar().ToString());

            string queryUpdateOrder = "update Zamowienia set status=2, DataZamowienia=GETDATE() where id= " + orderId;
            SqlCommand cmdUpdateOrder = new SqlCommand(queryUpdateOrder, connection);
            cmdUpdateOrder.ExecuteScalar();

            AddAmount2ToBudget();

            connection.Close();
            FillRightLabels();
        }

        private void deliveredDelivery1Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateLeftOrder();
            
        }

        private void deliveredDelivery2Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateRightOrder();
            
        }
        private void AddAmount1ToBudget()
        {
            double amount = Double.Parse(amount1Label.Content.ToString());

            double budget = 0.00;
            double newBudget = 0.00;

            string queryGetBudget = "SELECT Budzet FROM Administracja";
            SqlCommand cmdGetBudget = new SqlCommand(queryGetBudget, connection);
            budget = Double.Parse(cmdGetBudget.ExecuteScalar().ToString());

            newBudget = budget + amount;

            string queryUpdateOrder = "update Administracja set Budzet=  " + newBudget.ToString().Replace(",", ".");
            SqlCommand cmdUpdateOrder = new SqlCommand(queryUpdateOrder, connection);
            cmdUpdateOrder.ExecuteScalar();

            

            
        }
        private void AddAmount2ToBudget()
        {
            double amount = Double.Parse(amount2Label.Content.ToString());

            double budget = 0.00;
            double newBudget = 0.00;

            string queryGetBudget = "SELECT Budzet FROM Administracja";
            SqlCommand cmdGetBudget = new SqlCommand(queryGetBudget, connection);
            budget = Double.Parse(cmdGetBudget.ExecuteScalar().ToString());

            newBudget = budget + amount;

            string queryUpdateOrder = "update Administracja set Budzet=  " + newBudget.ToString().Replace(",", ".");
            SqlCommand cmdUpdateOrder = new SqlCommand(queryUpdateOrder, connection);
            cmdUpdateOrder.ExecuteScalar();

        }
    }   

}
