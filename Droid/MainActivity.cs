using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Groupster.Core;
using XLabs.Forms;

namespace Groupster.Droid
{
	[Activity (Label = "Groupster", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid //global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Xamarin.FormsMaps.Init (this, bundle);
			Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (App.Instance);
		}
	}
}

