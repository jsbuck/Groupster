using System;

using Xamarin.Forms;

namespace Groupster.Core
{

	public class App : Application
	{
		// just a singleton pattern so I can have the concept of an app instance
		static volatile App _instance;
		static object _syncRoot = new Object();

		public NavigationPage AppNavPage = null; //new NavigationPage (new RootPage ());

		private string _token;
		private GroupsterDatabase _database;

		public App() {
			MainPage = new NavigationPage(new LoginPage(null));
		}

		public static App Instance
		{
			get {
				if (_instance == null) {
					lock (_syncRoot) {
						if (_instance == null) {
							_instance = new App ();
							_instance.OAuthSettings = 
								new OAuthSettings (
									clientId: "",  		// your OAuth2 client id 
									scope: "",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
									authorizeUrl: "",  	// the auth URL for the service
									redirectUrl: "");   // the redirect URL for the service

							// If you'd like to know more about how to integrate with an OAuth provider, 
							// I personally like the Instagram API docs: http://instagram.com/developer/authentication/
						}
					}
				}

				return _instance;
			}
		}

		public static string Title = "Groupster";

		public GroupsterDatabase Database {
			get { 
				if (_database == null) {
					_database = new GroupsterDatabase ();
				}
				return _database; 
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

//		public bool IsLoggedIn {
//			get {
//				return !string.IsNullOrWhiteSpace (_token);
//			}
//		}
		public bool IsLoggedIn { get; set; }

		public string Token {
			get {
				return _token;
			}
		}

		public void SaveToken(string token) {
			_token = token;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}


	}
}

