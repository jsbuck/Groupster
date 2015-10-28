using System;

using Xamarin.Forms;

namespace Groupster.Core
{

	public class App : Application
	{
		static GroupsterDatabase database;

		public App ()
		{
			/*
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
			*/
		}

		public static GroupsterDatabase Database {
			get { 
				if (database == null) {
					database = new GroupsterDatabase ();
				}
				return database; 
			}
		}

		public static Page GetMainPage ()
		{	
			return new NavigationPage (new RootPage ());
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

