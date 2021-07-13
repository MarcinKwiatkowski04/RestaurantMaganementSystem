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
    /// Interaction logic for GetOrderWindow.xaml
    /// </summary>
    public partial class GetOrderWindow : Window
    {
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=Pizzeria;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public GetOrderWindow()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void backOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void saveOrderButton_Click(object sender, RoutedEventArgs e)
        {
            bool val = Validate();
            if (val) SendData();

        }
        public void FillComboBoxes()
        {
            connection.Open();

            string queryGetPizzaQuantity = " SELECT Count(id) FROM Pizze ";
            SqlCommand cmdGetPizzaQuantity = new SqlCommand(queryGetPizzaQuantity, connection);
            int iloscPizz = Int32.Parse((cmdGetPizzaQuantity.ExecuteScalar().ToString()));

            for (int i = 1; i <= iloscPizz; i++)
            {
                string queryGetPizza = " SELECT Nazwa FROM Pizze where id =" + i;
                SqlCommand cmdGetPizza = new SqlCommand(queryGetPizza, connection);
                pizza1CB.Items.Add(cmdGetPizza.ExecuteScalar().ToString());
                pizza2CB.Items.Add(cmdGetPizza.ExecuteScalar().ToString());
                pizza3CB.Items.Add(cmdGetPizza.ExecuteScalar().ToString());
                pizza4CB.Items.Add(cmdGetPizza.ExecuteScalar().ToString());
                pizza5CB.Items.Add(cmdGetPizza.ExecuteScalar().ToString());
            }

            paymentMethodInputCB.Items.Add("Karta płatnicza");
            paymentMethodInputCB.Items.Add("Gotówka");

            connection.Close();
        }

        public bool Validate()
        {
            if (cityInputTB.Text == "")
            {
                MessageBox.Show("Wprowadź miasto");
                return false;
            }
            else if (streetInputTB.Text == "")
            {
                MessageBox.Show("Wprowadź ulicę");
                return false;
            }
            else if (buildingNrInputTB.Text == "")
            {
                MessageBox.Show("Wprowadź numer budynku");
                return false;
            }
            else if (paymentMethodInputCB.SelectedItem == null)
            {
                MessageBox.Show("Wprowadź metodę płatności");
                return false;
            }
            else if (pizza1CB.SelectedItem == null)
            {
                MessageBox.Show("Wprowadź przynajmniej jedną pizzę");
                return false;
            }

            return true;
        }
        public void SendData()
        {
            int addressId = SendAddress();
            SendOrder(addressId);
            MessageBox.Show("Zapisano zamówienie");
            ClearInput();
        }
        public int SendAddress()
        {
            connection.Open();
            string queryGetHighestId = " SELECT Max(id) FROM Adresy ";
            SqlCommand cmdGetGetHighestId = new SqlCommand(queryGetHighestId, connection);
            int highestId = Int32.Parse((cmdGetGetHighestId.ExecuteScalar().ToString()));

            int paymentmethod = paymentMethodInputCB.SelectedIndex + 1;
            string apartmentNumber = apartmentNrInputTB.Text;
            string queryInsertAddress = "";
            Random deliveryCost = new Random();
            if (apartmentNumber != "")
            {
                queryInsertAddress = "INSERT INTO Adresy(Id, Miasto, Ulica, NrBudynku, NrMieszkania, KwotaDowozu) VALUES ('" + (highestId + 1) + "', '" + cityInputTB.Text + "', '" + streetInputTB.Text + "', '" + buildingNrInputTB.Text + "', " + apartmentNrInputTB.Text + ", " + deliveryCost.Next(1, 10) + ")";
            }
            else queryInsertAddress = "INSERT INTO Adresy(Id, Miasto, Ulica, NrBudynku, KwotaDowozu) VALUES (" + (highestId + 1) + ", '" + cityInputTB.Text + "', '" + streetInputTB.Text + "', '" + buildingNrInputTB.Text + "', " + deliveryCost.Next(1, 10) + ")";

            SqlCommand cmdInsertAddress = new SqlCommand(queryInsertAddress, connection);
            
            cmdInsertAddress.ExecuteScalar();

            connection.Close();

            return highestId + 1;

        }
        public void SendOrder(int addressId)
        {
            connection.Open();

            string queryGetHighestId = " SELECT Max(id) FROM Zamowienia ";
            SqlCommand cmdGetGetHighestId = new SqlCommand(queryGetHighestId, connection);
            int highestId = Int32.Parse((cmdGetGetHighestId.ExecuteScalar().ToString()));

            string pizza1;
            string pizza2 = null;
            string pizza3 = null;
            string pizza4 = null;
            string pizza5 = null;
            double kwota1, kwota2, kwota3, kwota4, kwota5, kwotaTotal;
            pizza1 = (pizza1CB.SelectedIndex+1).ToString();

            string queryGetAmount = " SELECT Cena FROM Pizze where id = " + Int32.Parse(pizza1);
            SqlCommand cmdGetAmount = new SqlCommand(queryGetAmount, connection);
            kwota1 = Double.Parse((cmdGetAmount.ExecuteScalar().ToString()));
            string querySendOrder="";

            kwotaTotal = kwota1;
            if (pizza2CB.SelectedIndex != -1) { pizza2 = (pizza2CB.SelectedIndex + 1).ToString(); ; queryGetAmount = " SELECT Cena FROM Pizze where id = " + pizza2; cmdGetAmount = new SqlCommand(queryGetAmount, connection); kwota2 = Double.Parse((cmdGetAmount.ExecuteScalar().ToString())); kwotaTotal += kwota2; pizza3 = null; pizza4 = null; pizza5 = null; }
            if (pizza3CB.SelectedIndex != -1) { pizza3 = (pizza3CB.SelectedIndex + 1).ToString(); ; queryGetAmount = " SELECT Cena FROM Pizze where id = " + pizza3; cmdGetAmount = new SqlCommand(queryGetAmount, connection); kwota3 = Double.Parse((cmdGetAmount.ExecuteScalar().ToString())); kwotaTotal += kwota3; pizza4 = null; pizza5 = null; }
            if (pizza4CB.SelectedIndex != -1) { pizza4 = (pizza4CB.SelectedIndex + 1).ToString(); ; queryGetAmount = " SELECT Cena FROM Pizze where id = " + pizza4; cmdGetAmount = new SqlCommand(queryGetAmount, connection); kwota4 = Double.Parse((cmdGetAmount.ExecuteScalar().ToString())); kwotaTotal += kwota4; pizza5 = null; }
            if (pizza5CB.SelectedIndex != -1) { pizza5 = (pizza5CB.SelectedIndex + 1).ToString(); ; queryGetAmount = " SELECT Cena FROM Pizze where id = " + pizza5; cmdGetAmount = new SqlCommand(queryGetAmount, connection); kwota5 = Double.Parse((cmdGetAmount.ExecuteScalar().ToString())); kwotaTotal += kwota5; }
            
            if(pizza2==null) querySendOrder = "INSERT INTO Zamowienia(Id, Pizza1Id, Kwota, Status, DataZamowienia, MetodaPlatnosci, IdAdresu ) VALUES (" + (highestId + 1) + ", " + pizza1 + ", "  + kwotaTotal + ", 0 , GETDATE(), " + paymentMethodInputCB.SelectedIndex + ", " + addressId + ")";
            else if(pizza3==null) querySendOrder = "INSERT INTO Zamowienia(Id, Pizza1Id, Pizza2Id, Kwota, Status, DataZamowienia, MetodaPlatnosci, IdAdresu ) VALUES (" + (highestId + 1) + ", " + pizza1 +  ", " + pizza2 + ", " + kwotaTotal + ", 0 , GETDATE(), " + paymentMethodInputCB.SelectedIndex + ", " + addressId + ")";
            else if(pizza4==null) querySendOrder = "INSERT INTO Zamowienia(Id, Pizza1Id, Pizza2Id, Pizza3Id, Kwota, Status, DataZamowienia, MetodaPlatnosci, IdAdresu ) VALUES (" + (highestId + 1) + ", " + pizza1 + ", " + pizza2 + ", " + pizza3 + ", " + kwotaTotal + ", 0 , GETDATE(), " + paymentMethodInputCB.SelectedIndex + ", " + addressId + ")";
            else if (pizza5==null) querySendOrder = "INSERT INTO Zamowienia(Id, Pizza1Id, Pizza2Id, Pizza3Id, Pizza4Id, Kwota, Status, DataZamowienia, MetodaPlatnosci, IdAdresu ) VALUES (" + (highestId + 1) + ", " + pizza1 + ", " + pizza2 + ", "  + pizza3 + ", "  + pizza4 + ", " + kwotaTotal + ", 0 , GETDATE(), " + paymentMethodInputCB.SelectedIndex + ", " + addressId + ")";
            else if (pizza5!=null) querySendOrder = "INSERT INTO Zamowienia(Id, Pizza1Id, Pizza2Id, Pizza3Id, Pizza4Id, Pizza5Id, Kwota, Status, DataZamowienia, MetodaPlatnosci, IdAdresu ) VALUES (" + (highestId + 1) + ", " + pizza1 + ", " + pizza2 + ", " + pizza3 + ", " + pizza4 + ", " + pizza5 + ", " + kwotaTotal + ", 0 , GETDATE(), " + paymentMethodInputCB.SelectedIndex + ", " + addressId + ")";
            SqlCommand cmdSendOrder = new SqlCommand(querySendOrder, connection);
            cmdSendOrder.ExecuteScalar();

            connection.Close();
        }
        public void ClearInput()
        {
            cityInputTB.Text = "";
            streetInputTB.Text = "";
            buildingNrInputTB.Text = "";
            apartmentNrInputTB.Text = "";
            paymentMethodInputCB.SelectedItem = null;
            pizza1CB.SelectedItem = null;
            pizza2CB.SelectedItem = null;
            pizza3CB.SelectedItem = null;
            pizza4CB.SelectedItem = null;
            pizza5CB.SelectedItem = null;
        }
    }
}
