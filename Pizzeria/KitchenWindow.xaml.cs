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
    /// Interaction logic for KitchenWindow.xaml
    /// </summary>
    public partial class KitchenWindow : Window
    {
        
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public int globalCurrentOrderId = 0;
        public KitchenWindow()
        {
            InitializeComponent();
            FillLabels();
            FillIndegriendts();
            FillIngredtientsComboBox();
            previousArrowButton.IsEnabled = false;
        }

        private void BackKitchenButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        public void FillLabels()
        {
            PizzaTB.Text = "";

            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            //USTAWIENIE LICZNIKA ILOSCI PIZZ DLA ZAMOWIENIA
            int counter = CheckPizzaQuantity();

            //USTAWIENIE GLOBALNEJ ZMIENNEJ Z WYBRANYM ZAMOWIENIEM
            string queryGetGlobalOrder1 = "SELECT top 1 Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
            SqlCommand cmdGetGlobalOrder1 = new SqlCommand(queryGetGlobalOrder1, connection);
            globalCurrentOrderId = Int32.Parse(cmdGetGlobalOrder1.ExecuteScalar().ToString());
            

            //POBRANIE KAZDEJ PIZZY DLA NAJSTARSZEGO ZAMOWIENIA
            if (counter >= 1)
            {
                string queryGetOrder1 = "SELECT top 1 Pizza1Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
                SqlCommand cmdGetOrder1 = new SqlCommand(queryGetOrder1, connection);
                int pizza1Id = Int32.Parse(cmdGetOrder1.ExecuteScalar().ToString());

                //Przetłumaczenie ID pizz na nazwy do wklejenia ich do zamówienia
                string queryGetPizza1 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza1Id where z.Pizza1Id = " + pizza1Id;
                SqlCommand cmdGetPizzaName1 = new SqlCommand(queryGetPizza1, connection);
                cmdGetPizzaName1.ExecuteScalar();
                string pizza1Name = cmdGetPizzaName1.ExecuteScalar().ToString();
                PizzaTB.Text += pizza1Name;
            }
            if (counter >= 2)
            {
                string queryGetOrder2 = "SELECT top 1 Pizza2Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
                SqlCommand cmdGetOrder2 = new SqlCommand(queryGetOrder2, connection);
                cmdGetOrder2.ExecuteScalar();
                int pizza2Id = Int32.Parse(cmdGetOrder2.ExecuteScalar().ToString());

                string queryGetPizza2 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza2Id where z.Pizza2Id = " + pizza2Id;
                SqlCommand cmdGetPizzaName2 = new SqlCommand(queryGetPizza2, connection);
                cmdGetPizzaName2.ExecuteScalar();
                string pizza2Name = cmdGetPizzaName2.ExecuteScalar().ToString();
                PizzaTB.Text =  PizzaTB.Text + Environment.NewLine + pizza2Name;
            }
            if (counter >= 3)
            {
                string queryGetOrder3 = "SELECT top 1 Pizza3Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
                SqlCommand cmdGetOrder3 = new SqlCommand(queryGetOrder3, connection);
                cmdGetOrder3.ExecuteScalar();
                int pizza3Id = Int32.Parse(cmdGetOrder3.ExecuteScalar().ToString());

                string queryGetPizza3 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza3Id where z.Pizza3Id = " + pizza3Id;
                SqlCommand cmdGetPizzaName3 = new SqlCommand(queryGetPizza3, connection);
                cmdGetPizzaName3.ExecuteScalar();
                string pizza3Name = cmdGetPizzaName3.ExecuteScalar().ToString();
                PizzaTB.Text =  PizzaTB.Text + Environment.NewLine + pizza3Name;
            }
            if (counter >= 4)
            {
                string queryGetOrder4 = "SELECT top 1 Pizza4Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
                SqlCommand cmdGetOrder4 = new SqlCommand(queryGetOrder4, connection);
                cmdGetOrder4.ExecuteScalar();
                int pizza4Id = Int32.Parse(cmdGetOrder4.ExecuteScalar().ToString());

                string queryGetPizza4 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza4Id where z.Pizza4Id = " + pizza4Id;
                SqlCommand cmdGetPizzaName4 = new SqlCommand(queryGetPizza4, connection);
                cmdGetPizzaName4.ExecuteScalar();
                string pizza4Name = cmdGetPizzaName4.ExecuteScalar().ToString();
                PizzaTB.Text =  PizzaTB.Text + Environment.NewLine + pizza4Name;
            }
            if (counter >= 5)
            {
                string queryGetOrder5 = "SELECT top 1 Pizza5Id FROM Zamowienia where status=0 order by SYSDATETIME() ";
                SqlCommand cmdGetOrder5 = new SqlCommand(queryGetOrder5, connection);
                cmdGetOrder5.ExecuteScalar();
                int pizza5Id = Int32.Parse(cmdGetOrder5.ExecuteScalar().ToString());

                string queryGetPizza5 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza5Id where z.Pizza5Id = " + pizza5Id;
                SqlCommand cmdGetPizzaName5 = new SqlCommand(queryGetPizza5, connection);
                cmdGetPizzaName5.ExecuteScalar();
                string pizza5Name = cmdGetPizzaName5.ExecuteScalar().ToString();                
                PizzaTB.Text = PizzaTB.Text+Environment.NewLine + pizza5Name;
            }

            connection.Close();
        }

        public int CheckPizzaQuantity()
        {
            int quantity = 0;
            

            string queryGetOldestOrderId = " SELECT top 1 Id FROM Zamowienia where status=0 order by SYSDATETIME()";
            SqlCommand cmdGetOldestOrderId = new SqlCommand(queryGetOldestOrderId, connection);
             int oldestOrderId = Int32.Parse(cmdGetOldestOrderId.ExecuteScalar().ToString());

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

        private void nextArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FillLabels2();
            nextArrowButton.IsEnabled = false;
            previousArrowButton.IsEnabled = true;
        }

        public void FillLabels2()
        {
            PizzaTB.Text = "";

            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            //USTAWIENIE LICZNIKA ILOSCI PIZZ DLA ZAMOWIENIA
            int counter = CheckPizzaQuantity2();

            //USTAWIENIE GLOBALNEJ ZMIENNEJ AKTUALNEGO ZAMOWIENIA
            string queryGetGlobalOrder1 = "SELECT top 1 Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
            SqlCommand cmdGetGlobalOrder1 = new SqlCommand(queryGetGlobalOrder1, connection);
            globalCurrentOrderId = Int32.Parse(cmdGetGlobalOrder1.ExecuteScalar().ToString());

            //POBRANIE KAZDEJ PIZZY DLA NAJSTARSZEGO ZAMOWIENIA
            if (counter >= 1)
            {
                string queryGetOrder1 = "SELECT TOP 1 Pizza1Id FROM(  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrder1 = new SqlCommand(queryGetOrder1, connection);
                int pizza1Id = Int32.Parse(cmdGetOrder1.ExecuteScalar().ToString());

                //Przetłumaczenie ID pizz na nazwy do wklejenia ich do zamówienia
                string queryGetPizza1 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza1Id where z.Pizza1Id = " + pizza1Id;
                SqlCommand cmdGetPizzaName1 = new SqlCommand(queryGetPizza1, connection);
                cmdGetPizzaName1.ExecuteScalar();
                string pizza1Name = cmdGetPizzaName1.ExecuteScalar().ToString();
                PizzaTB.Text += pizza1Name;
            }
            if (counter >= 2)
            {
                string queryGetOrder2 = "SELECT top 1 Pizza2Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrder2 = new SqlCommand(queryGetOrder2, connection);
                cmdGetOrder2.ExecuteScalar();
                int pizza2Id = Int32.Parse(cmdGetOrder2.ExecuteScalar().ToString());

                string queryGetPizza2 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza2Id where z.Pizza2Id = " + pizza2Id;
                SqlCommand cmdGetPizzaName2 = new SqlCommand(queryGetPizza2, connection);
                cmdGetPizzaName2.ExecuteScalar();
                string pizza2Name = cmdGetPizzaName2.ExecuteScalar().ToString();
                PizzaTB.Text = PizzaTB.Text + Environment.NewLine + pizza2Name;
            }
            if (counter >= 3)
            {
                string queryGetOrder3 = "SELECT top 1 Pizza3Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrder3 = new SqlCommand(queryGetOrder3, connection);
                cmdGetOrder3.ExecuteScalar();
                int pizza3Id = Int32.Parse(cmdGetOrder3.ExecuteScalar().ToString());

                string queryGetPizza3 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza3Id where z.Pizza3Id = " + pizza3Id;
                SqlCommand cmdGetPizzaName3 = new SqlCommand(queryGetPizza3, connection);
                cmdGetPizzaName3.ExecuteScalar();
                string pizza3Name = cmdGetPizzaName3.ExecuteScalar().ToString();
                PizzaTB.Text = PizzaTB.Text + Environment.NewLine + pizza3Name;
            }
            if (counter >= 4)
            {
                string queryGetOrder4 = "SELECT top 1 Pizza4Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrder4 = new SqlCommand(queryGetOrder4, connection);
                cmdGetOrder4.ExecuteScalar();
                int pizza4Id = Int32.Parse(cmdGetOrder4.ExecuteScalar().ToString());

                string queryGetPizza4 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza4Id where z.Pizza4Id = " + pizza4Id;
                SqlCommand cmdGetPizzaName4 = new SqlCommand(queryGetPizza4, connection);
                cmdGetPizzaName4.ExecuteScalar();
                string pizza4Name = cmdGetPizzaName4.ExecuteScalar().ToString();
                PizzaTB.Text = PizzaTB.Text + Environment.NewLine + pizza4Name;
            }
            if (counter >= 5)
            {
                string queryGetOrder5 = "SELECT top 1 Pizza5Id FROM (  SELECT TOP 2 *  FROM Zamowienia where status=0  ORDER BY ID) a ORDER BY ID DESC ";
                SqlCommand cmdGetOrder5 = new SqlCommand(queryGetOrder5, connection);
                cmdGetOrder5.ExecuteScalar();
                int pizza5Id = Int32.Parse(cmdGetOrder5.ExecuteScalar().ToString());

                string queryGetPizza5 = "SELECT Nazwa FROM Pizze p join Zamowienia z on p.Id = z.Pizza5Id where z.Pizza5Id = " + pizza5Id;
                SqlCommand cmdGetPizzaName5 = new SqlCommand(queryGetPizza5, connection);
                cmdGetPizzaName5.ExecuteScalar();
                string pizza5Name = cmdGetPizzaName5.ExecuteScalar().ToString();
                PizzaTB.Text = PizzaTB.Text + Environment.NewLine + pizza5Name;
            }

            

            connection.Close();
        }
        public int CheckPizzaQuantity2()
        {
            int quantity = 0;


            string queryGetOldestOrderId = " SELECT top 1 Id FROM (SELECT TOP 2 *  FROM Zamowienia  ORDER BY ID DESC) a order by SYSDATETIME()";       
            SqlCommand cmdGetOldestOrderId = new SqlCommand(queryGetOldestOrderId, connection);
            int oldestOrderId = Int32.Parse(cmdGetOldestOrderId.ExecuteScalar().ToString());

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

        private void previousArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FillLabels();
            previousArrowButton.IsEnabled = false;
            nextArrowButton.IsEnabled = true;
        }

        public void FillIndegriendts()
        {
            if(connection.State==System.Data.ConnectionState.Closed) connection.Open();

            string queryGetIngredient1 = " SELECT Nazwa FROM Skladniki where id =1";
            SqlCommand cmdGetIngredient1 = new SqlCommand(queryGetIngredient1, connection);
            ingredientsStateLabel.Content = cmdGetIngredient1.ExecuteScalar().ToString();

            string queryGetIngredient1quantity = " SELECT Ilosc FROM Skladniki where id =1";
            SqlCommand cmdGetIngredient1quantity = new SqlCommand(queryGetIngredient1quantity, connection);
            ingredientsStateLabel.Content += "                   " + cmdGetIngredient1quantity.ExecuteScalar().ToString();

            string queryGetIngredient2 = " SELECT Nazwa FROM Skladniki where id =2";
            SqlCommand cmdGetIngredient2 = new SqlCommand(queryGetIngredient2, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient2.ExecuteScalar().ToString();

            string queryGetIngredient2quantity = " SELECT Ilosc FROM Skladniki where id =2";
            SqlCommand cmdGetIngredient2quantity = new SqlCommand(queryGetIngredient2quantity, connection);
            ingredientsStateLabel.Content +=  "                " + cmdGetIngredient2quantity.ExecuteScalar().ToString();

            string queryGetIngredient3 = " SELECT Nazwa FROM Skladniki where id =3";
            SqlCommand cmdGetIngredient3 = new SqlCommand(queryGetIngredient3, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient3.ExecuteScalar().ToString();

            string queryGetIngredient3quantity = " SELECT Ilosc FROM Skladniki where id =3";
            SqlCommand cmdGetIngredient3quantity = new SqlCommand(queryGetIngredient3quantity, connection);
            ingredientsStateLabel.Content += "                              " + cmdGetIngredient3quantity.ExecuteScalar().ToString();

            string queryGetIngredient4 = " SELECT Nazwa FROM Skladniki where id =4";
            SqlCommand cmdGetIngredient4 = new SqlCommand(queryGetIngredient4, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient4.ExecuteScalar().ToString();

            string queryGetIngredient4quantity = " SELECT Ilosc FROM Skladniki where id =4";
            SqlCommand cmdGetIngredient4quantity = new SqlCommand(queryGetIngredient4quantity, connection);
            ingredientsStateLabel.Content += "                           " + cmdGetIngredient4quantity.ExecuteScalar().ToString();

            string queryGetIngredient5 = " SELECT Nazwa FROM Skladniki where id =5";
            SqlCommand cmdGetIngredient5 = new SqlCommand(queryGetIngredient5, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient5.ExecuteScalar().ToString();

            string queryGetIngredient5quantity = " SELECT Ilosc FROM Skladniki where id =5";
            SqlCommand cmdGetIngredient5quantity = new SqlCommand(queryGetIngredient5quantity, connection);
            ingredientsStateLabel.Content += "                              " + cmdGetIngredient5quantity.ExecuteScalar().ToString();

            string queryGetIngredient6 = " SELECT Nazwa FROM Skladniki where id =6";
            SqlCommand cmdGetIngredient6 = new SqlCommand(queryGetIngredient6, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient6.ExecuteScalar().ToString();

            string queryGetIngredient6quantity = " SELECT Ilosc FROM Skladniki where id =6";
            SqlCommand cmdGetIngredient6quantity = new SqlCommand(queryGetIngredient6quantity, connection);
            ingredientsStateLabel.Content += "                              " + cmdGetIngredient6quantity.ExecuteScalar().ToString();

            string queryGetIngredient7 = " SELECT Nazwa FROM Skladniki where id =7";
            SqlCommand cmdGetIngredient7 = new SqlCommand(queryGetIngredient7, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient7.ExecuteScalar().ToString();

            string queryGetIngredient7quantity = " SELECT Ilosc FROM Skladniki where id =7";
            SqlCommand cmdGetIngredient7quantity = new SqlCommand(queryGetIngredient7quantity, connection);
            ingredientsStateLabel.Content += "                               " + cmdGetIngredient7quantity.ExecuteScalar().ToString();


            string queryGetIngredient8 = " SELECT Nazwa FROM Skladniki where id =8";
            SqlCommand cmdGetIngredient8 = new SqlCommand(queryGetIngredient8, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient8.ExecuteScalar().ToString();

            string queryGetIngredient8quantity = " SELECT Ilosc FROM Skladniki where id =8";
            SqlCommand cmdGetIngredient8quantity = new SqlCommand(queryGetIngredient8quantity, connection);
            ingredientsStateLabel.Content += "                         " + cmdGetIngredient8quantity.ExecuteScalar().ToString();

            string queryGetIngredient9 = " SELECT Nazwa FROM Skladniki where id =9";
            SqlCommand cmdGetIngredient9 = new SqlCommand(queryGetIngredient9, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient9.ExecuteScalar().ToString();

            string queryGetIngredient9quantity = " SELECT Ilosc FROM Skladniki where id =9";
            SqlCommand cmdGetIngredient9quantity = new SqlCommand(queryGetIngredient9quantity, connection);
            ingredientsStateLabel.Content += "                             " + cmdGetIngredient9quantity.ExecuteScalar().ToString();

            string queryGetIngredient10 = " SELECT Nazwa FROM Skladniki where id =10";
            SqlCommand cmdGetIngredient10 = new SqlCommand(queryGetIngredient10, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient10.ExecuteScalar().ToString();

            string queryGetIngredient10quantity = " SELECT Ilosc FROM Skladniki where id =10";
            SqlCommand cmdGetIngredient10quantity = new SqlCommand(queryGetIngredient10quantity, connection);
            ingredientsStateLabel.Content += "                             " + cmdGetIngredient10quantity.ExecuteScalar().ToString();

            string queryGetIngredient11 = " SELECT Nazwa FROM Skladniki where id =11";
            SqlCommand cmdGetIngredient11 = new SqlCommand(queryGetIngredient11, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient11.ExecuteScalar().ToString();

            string queryGetIngredient11quantity = " SELECT Ilosc FROM Skladniki where id =11";
            SqlCommand cmdGetIngredient11quantity = new SqlCommand(queryGetIngredient11quantity, connection);
            ingredientsStateLabel.Content += "                          " + cmdGetIngredient11quantity.ExecuteScalar().ToString();

            string queryGetIngredient12 = " SELECT Nazwa FROM Skladniki where id =12";
            SqlCommand cmdGetIngredient12 = new SqlCommand(queryGetIngredient12, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient12.ExecuteScalar().ToString();

            string queryGetIngredient12quantity = " SELECT Ilosc FROM Skladniki where id =12";
            SqlCommand cmdGetIngredient12quantity = new SqlCommand(queryGetIngredient12quantity, connection);
            ingredientsStateLabel.Content += "                    " + cmdGetIngredient12quantity.ExecuteScalar().ToString();

            string queryGetIngredient13 = " SELECT Nazwa FROM Skladniki where id =13";
            SqlCommand cmdGetIngredient13 = new SqlCommand(queryGetIngredient13, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient13.ExecuteScalar().ToString();

            string queryGetIngredient13quantity = " SELECT Ilosc FROM Skladniki where id =13";
            SqlCommand cmdGetIngredient13quantity = new SqlCommand(queryGetIngredient13quantity, connection);
            ingredientsStateLabel.Content += "                          " + cmdGetIngredient13quantity.ExecuteScalar().ToString();

            string queryGetIngredient14 = " SELECT Nazwa FROM Skladniki where id =14";
            SqlCommand cmdGetIngredient14 = new SqlCommand(queryGetIngredient14, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient14.ExecuteScalar().ToString();

            string queryGetIngredient14quantity = " SELECT Ilosc FROM Skladniki where id =14";
            SqlCommand cmdGetIngredient14quantity = new SqlCommand(queryGetIngredient14quantity, connection);
            ingredientsStateLabel.Content += "                       " + cmdGetIngredient14quantity.ExecuteScalar().ToString();

            string queryGetIngredient15 = " SELECT Nazwa FROM Skladniki where id =15";
            SqlCommand cmdGetIngredient15 = new SqlCommand(queryGetIngredient15, connection);
            ingredientsStateLabel.Content += Environment.NewLine + cmdGetIngredient15.ExecuteScalar().ToString();

            string queryGetIngredient15quantity = " SELECT Ilosc FROM Skladniki where id =15";
            SqlCommand cmdGetIngredient15quantity = new SqlCommand(queryGetIngredient15quantity, connection);
            ingredientsStateLabel.Content += "                            " + cmdGetIngredient15quantity.ExecuteScalar().ToString();

            connection.Close();
        }
        public void FillIngredtientsComboBox()
        {
            connection.Open();

            string queryGetIngredientsQuantity = " SELECT Count(id) FROM Skladniki ";
            SqlCommand cmdGetIngredientsQuantity = new SqlCommand(queryGetIngredientsQuantity, connection);            
            int iloscSkladnikow = Int32.Parse((cmdGetIngredientsQuantity.ExecuteScalar().ToString()));

            for (int i =1; i <= iloscSkladnikow; i++)
            {
                string queryGetIngredient = " SELECT Nazwa FROM Skladniki where id =" + i;
                SqlCommand cmdGetIngredient = new SqlCommand(queryGetIngredient, connection);
                ingredientsComboBox.Items.Add(cmdGetIngredient.ExecuteScalar().ToString());                
            }

            connection.Close();
            
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderIngredient();
        }
        public void OrderIngredient()
        {
           const int maxStock = 50;

            string ingredient = ingredientsComboBox.SelectedItem.ToString();
            double price = 0.0;
            int quantity = 0;
            double prevBudget = 0.0;
            double currentBudget = 0.0;
            int quantityToOrder = 0;

            connection.Open();

            string queryGetIngredientPrice = " SELECT Cena FROM Skladniki where Nazwa = '" + ingredient + "' ";
            SqlCommand cmdGetIngredientPrice = new SqlCommand(queryGetIngredientPrice, connection);
            price = Double.Parse(cmdGetIngredientPrice.ExecuteScalar().ToString());

            string queryGetIngredientQuantity = " SELECT Ilosc FROM Skladniki where Nazwa = '" + ingredient + "' ";
            SqlCommand cmdGetIngredientQuantity = new SqlCommand(queryGetIngredientQuantity, connection);
            quantity = Int32.Parse(cmdGetIngredientQuantity.ExecuteScalar().ToString());
            quantityToOrder = maxStock - quantity;

            string queryGetBudget = " SELECT Budzet FROM Administracja";
            SqlCommand cmdGetBudget = new SqlCommand(queryGetBudget, connection);
            prevBudget = Double.Parse(cmdGetBudget.ExecuteScalar().ToString());

            currentBudget = prevBudget - (quantityToOrder * price);

            string queryUpdateBudget = " Update Administracja SET Budzet = " + currentBudget.ToString().Replace(",", ".");           
            SqlCommand cmdUpdateBudget = new SqlCommand(queryUpdateBudget, connection);
            
            cmdUpdateBudget.ExecuteScalar();

            string queryUpdateIngredients = " Update Skladniki SET Ilosc = " + maxStock + " where Nazwa = '" + ingredient + "' ";
            SqlCommand cmdUpdateIngredients = new SqlCommand(queryUpdateIngredients, connection);
            cmdUpdateIngredients.ExecuteScalar();

            MessageBox.Show("Zamowiono Skladniki");
            

            connection.Close();

            FillIndegriendts();
        }

        private void completeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteOrder();
        }
        public void CompleteOrder()
        {
            connection.Open();

            int pizzaQuantity = 0;
            if (previousArrowButton.IsEnabled == false) pizzaQuantity = CheckPizzaQuantity();
            else pizzaQuantity = CheckPizzaQuantity2();

            for (int i=1; i<=pizzaQuantity; i++)
            {
                string queryGetPizzaId = "SELECT Pizza" + i +"Id from Zamowienia where Id = " + globalCurrentOrderId;
                SqlCommand cmdGetPizzaId = new SqlCommand(queryGetPizzaId, connection);
                int pizzaId = Int32.Parse(cmdGetPizzaId.ExecuteScalar().ToString());

                int ingredientsQuantity = CheckIngredientsQuantity(pizzaId);
                for (int j=1; j<=ingredientsQuantity; j++)
                {
                    string queryGetIngredientId = "SELECT Skladnik" + j + "Id FROM Pizze where Id = " + pizzaId;
                    SqlCommand cmdGetIngredientId = new SqlCommand(queryGetIngredientId, connection);
                    int skladnikId = Int32.Parse(cmdGetIngredientId.ExecuteScalar().ToString());

                    string queryDecreaseIngredients = "Update Skladniki set Ilosc = Ilosc - 1 where Id = " + skladnikId;
                    SqlCommand cmdDecreaseIngredients = new SqlCommand(queryDecreaseIngredients, connection);
                    cmdDecreaseIngredients.ExecuteScalar();
                }
            } 
            FillIndegriendts();

            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            string queryUpdateStatus = "Update Zamowienia SET Status=1, DataZamowienia=GETDATE() where Id = " + globalCurrentOrderId;
            SqlCommand cmdUpdateStatus = new SqlCommand(queryUpdateStatus, connection);
            cmdUpdateStatus.ExecuteScalar();

            if (previousArrowButton.IsEnabled == false) FillLabels();
            else FillLabels2();



            connection.Close();
        }

        public int CheckIngredientsQuantity(int pizzaId)
        {
            int quantity = 0;  

            string queryCounter = "SELECT Skladnik1Id from Pizze where Id = " + pizzaId;
            SqlCommand cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Skladnik2Id from Pizze where Id = " + pizzaId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Skladnik3Id from Pizze where Id = " + pizzaId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            queryCounter = "SELECT Skladnik4Id from Pizze where Id = " + pizzaId;
            cmdCounter = new SqlCommand(queryCounter, connection);
            if (cmdCounter.ExecuteScalar().ToString() != "") quantity++;

            return quantity;
        }
    }
}
