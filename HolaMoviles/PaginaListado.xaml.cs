using HolaMoviles.Modelos;
using HolaMoviles.Servicios;
using Plugin.Connectivity;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HolaMoviles
{
    public partial class PaginaListado
	{
        //public const string WEB_SERVICE_URL = "http://cloud-services.azurewebsites.net/api/products";
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
		public Command AgregarCommand { get; set; }
		public Command RefrescarCommand { get; set; }
        public ApiService ServicioDatos { get; set; } = new ApiService();

		private string _data = @"[
		{
			""name"": ""pillow"",
			""price"": 5.0,
			""quantity"": 1.0
		}]";

		public string Data { get => _data; }

		public PaginaListado()
		{
			BindingContext = this;

			AgregarCommand = new Command(() => {
				Items.Add(new Producto
				{
					Nombre = $"Producto {(Items.Count + 1)}"
				}
				);

				// No tiene ningun efecto hacer ListViewDatos.ItemsSource = new int[] { 1, 2, 3};
			});

            IsBusy = true;
			RefrescarCommand = new Command(() => Refrescar());
			
			InitializeComponent();
            ListViewDatos.ItemSelected += ListViewDatos_ItemSelected;
		}

        private void ListViewDatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSeleccionado = e.SelectedItem;

            //var producto = (Producto)itemSeleccionado;
            var producto = itemSeleccionado as Producto; //otra forma de hacer cast

            Navigation.PushAsync(new HolaMoviles.DetelleProducto(producto));
            
            

            
        }

        private async void Refrescar()
		{
            await Task.Delay(2500);
            ListViewDatos.IsRefreshing = false;

            //IsBusy = false;

            //Con esto valido que exista internet en el celular
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Implosible continuar", "No hay conexion a internet", "Continuar");
                return;
            }

            try
            {
                //var cliente = new HttpClient();
                //cliente.BaseAddress = new Uri(WEB_SERVICE_URL);
                //cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //Si mi cliente quiere XML pongo text/xml            
                //var respuesta = await cliente.GetStringAsync(""); //Vacio ya que en el BaseAddress configure toda la ruta
                //var data = JsonConvert.DeserializeObject(_data);
                //var data = JsonConvert.DeserializeObject<Producto[]>(respuesta);
                //var data =  await ServicioDatos.GetStringAsync();
                var data = await ServicioDatos.GetStringAsync();



                Debug.WriteLine(data);
                foreach (var item in data)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("Ha ocurrido un error", ex.Message, "Continuar");
            }
            finally
            {
                ListViewDatos.IsRefreshing = false; //esto apaga el refrescar de la pantalla
            }

			

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Refrescar();
		}
	}
}
