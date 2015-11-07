using System;
using Xamarin.Forms;

namespace Groupster.Core
{
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsLoggedIn) {
				Navigation.PushModalAsync( new LoginPage() );
			}
		}
	}
}

