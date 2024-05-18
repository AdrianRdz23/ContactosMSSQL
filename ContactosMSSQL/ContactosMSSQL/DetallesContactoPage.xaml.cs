using ContactosMSSQL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactosMSSQL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesContactoPage : ContentPage
	{
		public Contacto Contacto { get; set; }
		public DetallesContactoPage (Contacto contacto)
		{
			InitializeComponent ();

			Contacto = contacto;

			nombreLabel.Text = $"{Contacto.Nombre} {Contacto.Apellido}";
			telefonoLabel.Text = Contacto.Telefono;
			correoLabel.Text = Contacto.Email;

		}
	}
}