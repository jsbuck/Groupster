using System;
using Xamarin.Forms;
using Groupster.Core;
using XLabs.Forms.Controls;

namespace Groupster.Core
{
	public class LoginPage : ContentPage
	{
		public LoginPage() {
		}

		public LoginPage (RootPage rootPage)
		{
			this._rootPage = rootPage;
			_db = new GroupsterDatabase();

			_viewModel = new LoginViewModel (Navigation, new User(), rootPage);
			BindingContext = _viewModel;

			Padding = 0;

			// Create layout and bind where appropriate.
			var loginMessageLabel = new LargeLabel {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 50,
				TextColor = Color.White,
				Text = "Welcome to Groupster",
				FontSize = 30 //Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			BackgroundColor = AppColors.BaseColor;

			var loginImage = new Image ();

			loginImage.SetBinding<LoginViewModel> (Image.SourceProperty, vm => vm.LoginImage);

			var usernameEntry = new Entry {
				Placeholder = "Email",
			};

			usernameEntry.SetBinding(Entry.TextProperty, "UserNameMessage");

			var passwordEntry = new Entry {
				Placeholder = "Password",
				IsPassword = true
			};

			passwordEntry.SetBinding(Entry.TextProperty, "PasswordMessage");

			var switchLabel = new Label {
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				Text = "Remember Me?",
			};

			var rememberMeOption = new  CheckBox {
				BackgroundColor = AppColors.BaseColor
			};

			rememberMeOption.SetBinding(CheckBox.CheckedProperty, "RememberMe");

			var switchStackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				Spacing = 10,

				Orientation = StackOrientation.Horizontal,
				Children = {
					switchLabel,
					rememberMeOption
				}
			};

			var loginButton = new Button { 
				Text = "Login", 
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = AppColors.Button	
			};
			loginButton.Clicked += LogMeIn;

//			var registerButton = new Button { 
//				Text = "Close", 
//				HorizontalOptions = LayoutOptions.Center 
//			};
//
//			var buttonLayout = new StackLayout {
//				HorizontalOptions = LayoutOptions.Center,
//				Spacing = 10,
//				Orientation = StackOrientation.Horizontal,
//				Children = {
//					loginButton,
//					registerButton
//				}
//			};

			var registerLabel = new Label {
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 40,
				Text = "New to Groupster?",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};

			var registerLink = new Label {
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 40,
				Text = "Register here",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Italic
			};

//			var registerLink = new Button { 
//				Text = "Register here", 
//				HorizontalOptions = LayoutOptions.Center,
//				VerticalOptions = LayoutOptions.End,
//				HeightRequest = 20,
//				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
//				FontAttributes = FontAttributes.Italic,
//				BackgroundColor = AppColors.BaseColor,
//				TextColor = Color.Default
//			};
//
//			registerLink.Clicked += RegisterMe;

			var registerLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				Children = {
					new Label{},
					registerLabel,
					registerLink
				}
			};

			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Spacing = 10,
			};

			stackLayout.Children.Add (loginMessageLabel);
			stackLayout.Children.Add (loginImage); 	
			stackLayout.Children.Add (usernameEntry);
			stackLayout.Children.Add (passwordEntry);
			stackLayout.Children.Add (switchStackLayout);
			stackLayout.Children.Add (loginButton); 	
			stackLayout.Children.Add (registerLayout); 	

			Content = stackLayout;
		}

		RootPage _rootPage;

		LoginViewModel _viewModel {
			get;
			set;
		}

		GroupsterDatabase _db {
			get;
			set;
		}

		async void LogMeIn(object sender, EventArgs eventArgs)
		{
			App.Instance.IsLoggedIn = _viewModel.CanLogin();

			if (App.Instance.IsLoggedIn) {
				var navPage = new NavigationPage (new RootPage ());
				navPage.BarBackgroundColor = AppColors.BaseColor;
				navPage.BarTextColor = Color.White;
				Application.Current.MainPage = navPage;
			};

		}

		async void RegisterMe(object sender, EventArgs eventArgs)
		{
			App.Instance.IsLoggedIn = _viewModel.CanLogin();

			if (!App.Instance.IsLoggedIn) {
			};

		}

	}
}

