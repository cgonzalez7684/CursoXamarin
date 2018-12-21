using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HolaMoviles
{
	public partial class MainPage
	{
		public Command NavegarCommand { get; set; }

		public MainPage()
		{
			InitializeComponent();

			ToolbarItem2.Order = ToolbarItemOrder.Secondary;

			boton1.Command = new Command(() => MostrarComando());

			boton1.Clicked += async(sender, e) => {

				var saludo = $"Hola,{entryNombre.Text} + { 123 }";

				await Task.Delay(3500);

				await DisplayAlert("Mensaje importante", saludo, "Cerrar");
			};

			ToolbarItem1.Command = boton1.Command;
			ToolbarItem2.Command = ToolbarItem1.Command;

			NavegarCommand = new Command(() => {

				Navigation.PushAsync(new PaginaTabs());
			});

			botonNavegar.Command = NavegarCommand;
		}

		private void MostrarComando()
		{
			DisplayAlert("Mensaje por comando", "Hola!", "Terminar");

			Panel3.Children.Add(new Button
			{
				Command = boton1.Command,
				Text = Panel3.Children.Count.ToString()
			});
		}
	}
}
