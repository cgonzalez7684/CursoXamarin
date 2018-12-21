using Newtonsoft.Json;
using System;
namespace HolaMoviles.Modelos
{
	public class Producto
	{
        [JsonProperty(PropertyName = "Name")]
		public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Precio { get; set; }

        [JsonProperty(PropertyName = "Quantity")]  //Esta notacion es para que la desarializacion asocie las propiedades con lo que trae el JSON del servidor
        public decimal Cantidad { get; set; }

        public string RutaImagen { get; set; } = "https://cdn0.iconfinder.com/data/icons/business-mix/512/cargo-512.png";
	}
}
