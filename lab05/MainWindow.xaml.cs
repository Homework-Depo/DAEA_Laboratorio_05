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

namespace lab05
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

        private void SaveClient(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=lab1504-12\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=sa;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertClient", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idClient", txtidClient.Text);
                    cmd.Parameters.AddWithValue("@nombreCompania", txtNombreCompania.Text);
                    cmd.Parameters.AddWithValue("@nombreContacto", txtNombreContacto.Text);
                    cmd.Parameters.AddWithValue("@cargoContacto", txtCargoContacto.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@codPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@fax", txtFax.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el cliente: " + ex.Message);
            }
        }

        private void ListClients(object sender, RoutedEventArgs e)
        {
            Listado listado = new Listado();
            listado.Show();
        }
    }
}
