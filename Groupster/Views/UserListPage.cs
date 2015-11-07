using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;


namespace Groupster.Core
{
	public class UserListPage : ContentPage
	{
		ListView _userList;
		ObservableCollection<User> _users = new ObservableCollection<User>();

		public UserListPage()
		{
			loadUsersForDisplay();
			Title = "user List";

			createUserListView();

			Content = _userList;
		}

		void loadUsersForDisplay()
		{
			if (App.Instance.IsLoggedIn)
			{
				if (_users.Count == 0)
				{
					// Create user test data.
					_users = generateUserTestData();
				}
			}
		}

		void createUserListView()
		{
			_userList = new ListView
			{
				RowHeight = 50,
				ItemTemplate = new DataTemplate(typeof(UserCell))
			};
			_userList.ItemSelected  += userListOnItemSelected;
		}

		ObservableCollection<User> generateUserTestData() 
		{
			List<User> list = new List<User>
			{
				new User { ID = 1, Name = "Scott Buck", Gender = "Male", ImageFile = "CecilKinross" },
				new User { ID = 2, Name = "Ryan Buck", Gender = "Male", ImageFile = "WilliamHall" },
				new User { ID = 3, Name = "Syrel Torkelson", Gender = "Female", ImageFile = "PaulTriquet" },
				new User { ID = 4, Name = "Max Monson", Gender = "Male", ImageFile = "RobertSpall" },
			};

			return new ObservableCollection<User>(list.OrderBy(e => e.Name));
		}

		/// <summary>
		///   This method is invoked when the user selects an employee. Will open up the EmployeeDetailsPage for that employee.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArg">Event argument.</param>
		async void userListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView listView = (ListView)sender;
			if (listView.SelectedItem == null)
			{
				return;
			}

			await Navigation.PushAsync(new UserDetailPage((User)e.SelectedItem));
			listView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			// This method is invoked by Xamarin.Forms at some point when the 
			// page is being displayed.
			base.OnAppearing();
			loadUsersForDisplay();
			_userList.ItemsSource = _users;

		}
	}
}



