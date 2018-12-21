using System;
using System.Collections.Generic;
using System.Text;
using HolaMoviles.Modelos;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HolaMoviles.Servicios
{
    public class ApiService
    {
        public const string WEB_SERVICE_URL = "http://cloud-services.azurewebsites.net/api/products";

        public async Task<Producto[]> GetStringAsync()
        {
            //La clase HttpClient implementa la interfaz IDisposable lo que obliga a destruir de alguna forma
            //el objeto que cree con esta clase de forma directa.
            using (HttpClient cliente = new HttpClient())
            {                
                cliente.BaseAddress = new Uri(WEB_SERVICE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //Si mi cliente quiere XML pongo text/xml            
                var respuesta = await cliente.GetStringAsync(""); //Vacio ya que en el BaseAddress configure toda la ruta
                var data = JsonConvert.DeserializeObject<Producto[]>(respuesta);
                System.Diagnostics.Debug.WriteLine(data); //Solo para debug
                return data;
                
            }
            //var cliente = new HttpClient();
            //cliente.BaseAddress = new Uri(WEB_SERVICE_URL);
            //cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //Si mi cliente quiere XML pongo text/xml            
            //var respuesta = await cliente.GetStringAsync(""); //Vacio ya que en el BaseAddress configure toda la ruta
            //var data = JsonConvert.DeserializeObject<Producto[]>(respuesta);
            //System.Diagnostics.Debug.WriteLine(data); //Solo para debug
            //return data;
        }

        public async Task<Producto[]> GetAsync()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(WEB_SERVICE_URL);
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //Si mi cliente quiere XML pongo text/xml            
            var respuesta = await cliente.GetAsync(""); //Vacio ya que en el BaseAddress configure toda la ruta
            if (respuesta.IsSuccessStatusCode) //Esta propiedad le permite al cliente que saber que la respuesta fue satisfactorai
            {
                return new Producto[0];
            }

            var content = await respuesta.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Producto[]>(content);
            System.Diagnostics.Debug.WriteLine(data); //Solo para debug
            return data;
        }

    }
}
