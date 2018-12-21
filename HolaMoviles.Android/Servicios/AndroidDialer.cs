using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.App;
using HolaMoviles.Servicios;

namespace HolaMoviles.Droid.Servicios
{
    public class AndroidDialer : IDialer
    {
        public void Llamar(string numeroTelefono)
        {
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse("tel: " + numeroTelefono));
            Xamarin.Forms.Forms.Context.StartActivity(intent);
            

        }

        
    }
}