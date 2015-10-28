using System;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Groupster.Core
{
	public class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);

			var optionsPage = new MenuPage { Title = "Menu" };

			optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as OptionItem, null);

			Master = optionsPage;
			Detail = new ContentPage ();

			ShowLoadingDialogAsync ();
		}

		public async Task ShowLoadingDialogAsync ()
		{
			var page = new LoadingPage (this);
			await Navigation.PushModalAsync (page);
		}

		OptionItem previousItem;
		public Forecast GroupForecast;

		public void NavigateTo (OptionItem option, object parameters)
		{
			if (previousItem != null)
				previousItem.Selected = false;

			option.Selected = true;
			previousItem = option;
			Title = option.Title;


			if (Device.OS == TargetPlatform.WinPhone) {
				Detail = new ContentPage ();//work around to clear current page.
			}

			Detail = PageForOption (option, parameters);

			IsPresented = false;
		}

		Page PageForOption (OptionItem option, object parameters)
		{
			if (option.Title == "Forecast" && parameters == null) {
				ShowLoadingDialogAsync ();
				return new ContentPage ();
			}

			if (option.Title == "Forecast")
				return new ForecastPage (this, (Forecast)parameters);

			throw new NotImplementedException ("Unknown menu option: " + option.Title);
		}
	}
}

