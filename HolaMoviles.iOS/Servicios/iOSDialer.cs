using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using HolaMoviles.Servicios;
using UIKit;
using Foundation;


namespace HolaMoviles.iOS.Servicios
{
    public class iOSDialer : IDialer
    {
        public void Llamar(string numeroTelefono)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + numeroTelefono));
        }
    }
}