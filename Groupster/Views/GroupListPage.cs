using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;


namespace Groupster.Core
{
	public class GroupListPage : ContentPage
	{
		ListView _groupList;
		ObservableCollection<Group> _groups = new ObservableCollection<Group>();
		ToolbarItem _loginToolbarButton;

		public GroupListPage()
		{
			loadGroupsForDisplay();
			Title = "Group List";

			CreateLoginToolbarButton();
			createGroupListView();

			Content = _groupList;
		}

		void CreateLoginToolbarButton()
		{
			if (_loginToolbarButton != null)
			{
				return;
			}

			// There is a bug with Android which prevents the use of null for the iconName.
//			string iconName = Device.OnPlatform(null, "ic_action_content_new.png", null);
//			_loginToolbarButton = new ToolbarItem("Login", iconName, async () => {
//				ToolbarItems.Remove(_loginToolbarButton);
//				await  Navigation.PushAsync(new LoginPage());
//			});
		}

		void loadGroupsForDisplay()
		{
			if (App.Instance.IsLoggedIn)
			{
				if (_groups.Count == 0)
				{
					// Create group test data.
					_groups = generateGroupTestData();
				}
			}
		}

		void createGroupListView()
		{
			_groupList = new ListView
			{
				RowHeight = 50,
				ItemTemplate = new DataTemplate(typeof(GroupCell))
			};
			_groupList.ItemSelected  += GroupListOnItemSelected;
		}

		ObservableCollection<Group> generateGroupTestData() 
		{
			List<Group> list = new List<Group>
			{
				new Group { ID = 1, Name = "O'Blarneys", StartOn = DateTime.Now.AddDays(4).AddMinutes(45), ImageFile = "oblarneys.jpg" },
				new Group { ID = 2, Name = "Girls Night Out", StartOn = DateTime.Now.AddDays(1).AddMinutes(197), ImageFile = "GirlsNightOut.jpg" },
				new Group { ID = 3, Name = "Zac Brown Concert", StartOn = DateTime.Now.AddDays(25).AddMinutes(4545), ImageFile = "zacbrownband.jpg" },
				new Group { ID = 4, Name = "Edgefield Weekend", StartOn = DateTime.Now.AddDays(90).AddMinutes(2755), ImageFile = "PassportCopter" },
				new Group { ID = 5, Name = "Husky Game", StartOn = DateTime.Now.AddDays(7).AddMinutes(5), ImageFile = "W" }
			};

//			int counter = 1;
//			foreach (Group group in list)
//			{
//				group.Twitter = "@fake" + counter++;
//			}
			return new ObservableCollection<Group>(list.OrderBy(e => e.StartOn));
		}

		/// <summary>
		///   This method is invoked when the user selects an employee. Will open up the EmployeeDetailsPage for that employee.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArg">Event argument.</param>
		async void GroupListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView listView = (ListView)sender;
			if (listView.SelectedItem == null)
			{
				return;
			}

			await Navigation.PushAsync(new GroupDetailPage((Group)e.SelectedItem));
			listView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			// This method is invoked by Xamarin.Forms at some point when the 
			// page is being displayed.
			base.OnAppearing();
			loadGroupsForDisplay();
			_groupList.ItemsSource = _groups;

		}
	}
}



