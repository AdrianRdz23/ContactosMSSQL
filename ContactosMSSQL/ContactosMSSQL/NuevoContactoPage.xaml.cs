using ContactosMSSQL.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactosMSSQL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoContactoPage : ContentPage
    {
        public NuevoContactoPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs args)
        {
            Contacto nuevoContacto = new Contacto()
            {
                Nombre = nombreEntry.Text,
                Apellido = apellidoEntry.Text,
                Telefono = telefonoEntry.Text,
                Email = emailEntry.Text,
            };

            string connectionString = "Data Source=ADRRDZ23;Initial Catalog=Cursos;Integrated Security=True";
            //string connectionString = "Server=ADRRDZ23;Database=Cursos;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Contacto (Nombre, Apellido, Telefono, Email) VALUES (@Nombre, @Apellido, @Telefono, @Email)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nombre", nuevoContacto.Nombre);
                command.Parameters.AddWithValue("@Apellido", nuevoContacto.Apellido);
                command.Parameters.AddWithValue("@Telefono", nuevoContacto.Telefono);
                command.Parameters.AddWithValue("@Email", nuevoContacto.Email);

                command.ExecuteNonQuery();
            }

            await Navigation.PopAsync();
        }
    }
}