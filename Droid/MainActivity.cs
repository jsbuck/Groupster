using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Groupster.Core;

namespace Groupster.Droid
{
	[Activity (Label = "Groupster.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Xamarin.FormsMaps.Init (this, bundle);
			Xamarin.Forms.Forms.Init (this, bundle);

            //LoadApplication()
            SetPage (App.GetMainPage ());
		}
	}
}

