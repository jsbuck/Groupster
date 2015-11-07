using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Groupster.Core
{
	/// <summary>
	///   This class is used to capture login credentials and to perform very simple authentication.
	/// </summary>
	class LoginInfo : INotifyPropertyChanged
	{
		Color _loginColor = AppColors.BackgroundGrey;
		string _password = string.Empty;
		string _username = string.Empty;
		bool _rememberMe = false;

		public string UserName
		{
			get { return _username; }
			set
			{
				if (_username.Equals(value, StringComparison.Ordinal))
				{
					return;
				}
				_username = value ?? string.Empty;
				OnPropertyChanged();

				CanLogin();
			}
		}
		public string Password
		{
			get { return _password; }
			set
			{
				if (_password.Equals(value, StringComparison.Ordinal))
				{
					return;
				}
				_password = value ?? string.Empty;
				OnPropertyChanged();

				CanLogin();
			}
		}

		public bool RememberMe
		{
			get { return _rememberMe; }
			set
			{
				if (_rememberMe.Equals(value))
				{
					return;
				}
				_rememberMe = value;
				OnPropertyChanged();

				CanLogin();
			}
		}

		/// <summary>
		///   Gets or sets the login button colour.
		/// </summary>
		/// <value>The login button colour.</value>
		public Color LoginButtonColor
		{
			set
			{
				if (_loginColor == value)
				{
					return;
				}
				_loginColor = value;
				OnPropertyChanged();
			}

			get { return _loginColor; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///   Logic that determines if the user has entered the proper login information.
		///   Will set the .LoginButtonColour to a Light Blue if the user can login.
		/// </summary>
		/// <returns><c>true</c> if the user can login; otherwise, <c>false</c>.</returns>
		public bool CanLogin()
		{
			bool login = !string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password);
			LoginButtonColor = login ? AppColors.LightBlue : AppColors.BackgroundGrey;
			return login;
		}

		/// <summary>
		///   Helper method that will raise the PropertyChanged event when a property is changed.
		/// </summary>
		/// <param name="propertyName">
		///   Name of the property that was updated. If null then [CallerMemberName] will set it to the name of the
		///   member that invoked it.
		/// </param>
		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
