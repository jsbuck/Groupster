using System;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Groupster.Core
{
	public class RootPage : TabbedPage
	{
		public RootPage ()
		{
			// Hide the navigation bar for now.
			//NavigationPage.SetHasNavigationBar (this, false);

			// Add tabs.
			this.Children.Add(new GroupListPage () { Title = "Groups", Icon = "" });
			this.Children.Add (new UserListPage () { Title = "Friends", Icon = "" });

			setPageTitle(App.Title);
			//this.CurrentPageChanged += OnPageChanged;

		}

		OptionItem previousItem;

		public void NavigateTo (OptionItem option, object parameters)
		{
			if (previousItem != null)
				previousItem.Selected = false;

			option.Selected = true;
			previousItem = option;
			Title = option.Title;


			//Content = PageForOption (option, parameters);

			//IsPresented = false;
		}

		void setPageTitle(string title)
		{
			Title = string.Format ("  {0}", title);
		}

		Page PageForOption (OptionItem option, object parameters)
		{
			if (option.Title == "Groups" && parameters == null) {
				//ShowGroupDialogAsync ();
				return new ContentPage ();
			}

			if (option.Title == "Groups")
				return new ContentPage ();

			throw new NotImplementedException ("Unknown menu option: " + option.Title);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

//			if (!App.Instance.IsLoggedIn) {
//				ShowLoginDialogAsync();
//				//Navigation.PushModalAsync( new LoginPage(this) );
//			}
		}

		async void OnPageChanged(object sender, EventArgs eventArgs)
		{
			setPageTitle(this.CurrentPage.Title);
		}


	}
}

