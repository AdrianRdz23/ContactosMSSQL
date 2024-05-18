using ContactosMSSQL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactosMSSQL
{
    public partial class MainPage : ContentPage
    {
        List<Contacto> contactos;
        public MainPage()
        {
            InitializeComponent();

            contactos = new List<Contacto>();

            contactosListView.ItemSelected += Contactos_ListView_ItemSelected;
        }

        private void Contactos_ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contactoSeleccionado = e.SelectedItem as Contacto;

            Navigation.PushAsync(new DetallesContactoPage(contactoSeleccionado));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //string connectionString = "Data Source=ADRRDZ23;Initial Catalog=Cursos;Integrated Security=True TrustServerCertificate=True";
            string connectionString = "Server=ADRRDZ23;Database=Cursos;Integrated Security=True;TrustServerCertificate=True";

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Contacto";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contacto = new Contacto
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                        contactos.Add(contacto);
                    }
                }
            }

            contactosListView.ItemsSource = contactos;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevoContactoPage());
        }
    }
}
