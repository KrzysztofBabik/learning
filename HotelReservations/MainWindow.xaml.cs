using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Globalization;
using System.Threading;

namespace HotelReservations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        }

        public string conString = "Data Source=DESKTOP-3BMIDES\\SQLEXPRESS;Initial Catalog=HotelDatabase3;Integrated Security=True";
        
        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);
            
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string add = "insert into Customers(FirstName,LastName,Mail,Phone)values('" + txtFirstName.Text.ToString() + "', '" + txtLastName.Text.ToString() + "', '" + txtMail.Text.ToString() + "', '" + txtPhone.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(add, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer added!");
            }
        }

        private void searchCustomer_Click(object sender, RoutedEventArgs e)
        {
            string search = "SELECT * FROM Customers WHERE " +
                "FirstName LIKE '%" + txtFirstName.Text.ToString() + "%' AND " +
                "LastName LIKE '%" + txtLastName.Text.ToString() + "%' AND " +
                "Mail LIKE '%" + txtMail.Text.ToString() + "%' AND " +
                "Phone LIKE '%" + txtPhone.Text.ToString() + "%'";

            SqlConnection connection = new SqlConnection(conString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(search, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void addReservation_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);

            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string add = "insert into Reservations(CustomerID, RoomID, DateFrom, DateTo)values('" + int.Parse(txtCustomerID.Text) + "', '" + int.Parse(txtRoomID.Text) + "', '" + txtDateFrom.Text + "', '" + txtDateTo.Text + "')";
                
                SqlCommand cmd = new SqlCommand(add, connection);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Reservation added!");
            }
        }
        
        private void txtShow_Click(object sender, RoutedEventArgs e)
        {
            string show = "SELECT ReservationID, CustomerID, RoomID, DateFrom, DateTo FROM Reservations ORDER BY DateFrom DESC";
            
            SqlConnection connection = new SqlConnection(conString);
            
            connection.Open();

            SqlCommand cmd = new SqlCommand(show, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridReservations.ItemsSource = dt.DefaultView;
        }

        private void deleteReservation_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);

            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string delete = "DELETE Reservations WHERE ReservationID = '" + int.Parse(txtDelete.Text) + "' ";

                SqlCommand cmd = new SqlCommand(delete, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Reservation deleted!");
            }
        }

        private void updateReservation_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);

            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string update = "UPDATE Reservations SET CustomerID = '" + int.Parse(txtCustomerID.Text) + "', RoomID = '" + int.Parse(txtRoomID.Text) + "', DateFrom = '" + txtDateFrom.Text.ToString() + "', DateTo = '" + txtDateTo.Text.ToString() + "' WHERE ReservationID = '" + int.Parse(txtReservationID.Text) + "' ";

                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Reservation uptade!");
            }
        }
    }
}
