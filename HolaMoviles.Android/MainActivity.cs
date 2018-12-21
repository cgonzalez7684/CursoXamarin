using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HolaMoviles.Servicios;
using HolaMoviles.Droid.Servicios;

namespace HolaMoviles.Droid
{
	[Activity(Label = "HolaMoviles", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.Forms.DependencyService.Register<IDialer,AndroidDialer>(); //Esto sirve para vincular la interfaz a la accion a realizar si el contexto es Android
			LoadApplication(new App()); //Carga el aplicativo android
		}
	}
}

