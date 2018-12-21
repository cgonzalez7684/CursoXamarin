using HolaMoviles.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HolaMoviles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetelleProducto : ContentPage
	{
		public DetelleProducto ()
		{
			InitializeComponent ();
		}

        public DetelleProducto(Producto objProducto)
        {
            // BindingContext es lo que hace que los Bindings de la interfaz considere lo asignado como
            // referencia de datos

            BindingContext = objProducto;

            InitializeComponent();
            botonLlamada.Command = new Command(()=> {
                                                    Servicios.IDialer dialer = DependencyService.Get<Servicios.IDialer>(); //ayuda a resolver
                                                    dialer.Llamar("2258-8562");
                                                });
        }
	}
}