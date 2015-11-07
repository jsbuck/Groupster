using System;
using Groupster.Core.Services;
using Xamarin.Forms;

namespace Groupster.Core
{
	public class LoginViewModel : BaseViewModel
	{
		Color _loginColor = AppColors.BackgroundGrey;

		public LoginViewModel (INavigation navigation, User credentials, RootPage rootPage)
		{
			this.rootPage = rootPage;
			_navigation = navigation;
			_credentials = credentials;

			LoginImage = "Groupster72_white_0F7800.png";
			//IsRefreshButtonVisible = false;
			//IsActivityIndicatorVisible = false;

		}

		RootPage rootPage;
		INavigation _navigation;
		User _credentials;

		private string _loginMessage;

		public string LoginMessage {
			get { return _loginMessage; }
			set { ChangeAndNotify (ref _loginMessage, value); }
		}

		private string _groupsterMessage;

		public string GroupsterMessage {
			get { return _groupsterMessage; }
			set { ChangeAndNotify (ref _groupsterMessage, value); }
		}

		private string _userNameMessage;

		public string UserNameMessage {
			get { return _userNameMessage; }
			set { ChangeAndNotify (ref _userNameMessage, value); }
		}

		private string _passwordMessage;

		public string PasswordMessage {
			get { return _passwordMessage; }
			set { ChangeAndNotify (ref _passwordMessage, value); }
		}

		private bool _rememberMe;

		public bool RememberMe {
			get { return _rememberMe; }
			set { ChangeAndNotify (ref _rememberMe, value); }
		}

		private string _loginImage;

		public string LoginImage {
			get { return _loginImage; }
			set { ChangeAndNotify (ref _loginImage, value); }
		}

		/// <summary>
		///   Gets or sets the login button colour.
		/// </summary>
		/// <value>The login button colour.</value>
		public Color LoginButtonColor
		{
			get { return _loginColor; }
			set { ChangeAndNotify (ref _loginColor, value); }
		}

		/// <summary>
		///   Logic that determines if the user has entered the proper login information.
		///   Will set the .LoginButtonColour to a Light Blue if the user can login.
		/// </summary>
		/// <returns><c>true</c> if the user can login; otherwise, <c>false</c>.</returns>
		public bool CanLogin()
		{
			bool login = !string.IsNullOrWhiteSpace(_userNameMessage) && !string.IsNullOrWhiteSpace(_passwordMessage);
			LoginButtonColor = login ? AppColors.BaseColor : AppColors.BackgroundGrey;
			return login;
		}


	}
}

