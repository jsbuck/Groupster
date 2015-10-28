using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groupster.Core
{
	public class ForecastViewModel : BaseViewModel
	{
		readonly INavigation navigation;

		readonly Forecast forecast;

		public ForecastViewModel (INavigation navigation, Forecast forecast)
		{
			this.forecast = forecast;
			this.navigation = navigation;

			ScheduledGroupCount = forecast.ScheduledGroupsCount.ToString ();

			if (forecast.ScheduledGroupsCount == 1)
				ScheduledGroupText = "event";
			else
				ScheduledGroupText = "events";
				
			Reason = forecast.Reason;
			GroupList = forecast.GroupList;
		}

		private string _reason;

		public string Reason {
			get { return _reason; }
			set { ChangeAndNotify (ref _reason, value); }
		}

		private List<GroupViewTemplate> _groupList;

		public List<GroupViewTemplate> GroupList {
			get {
				if (_groupList == null) {
					_groupList = new List<GroupViewTemplate> ();
				}
				return _groupList;
			}
			set { ChangeAndNotify (ref _groupList, value); }
		}

		private string _scheduledGroupCount;

		public string ScheduledGroupCount {
			get { return _scheduledGroupCount; }
			set { ChangeAndNotify (ref _scheduledGroupCount, value); }
		}

		private string _scheduledGroupText;

		public string ScheduledGroupText {
			get { return _scheduledGroupText; }
			set { ChangeAndNotify (ref _scheduledGroupText, value); }
		}

		private Command _showGroupMembersMapCommand;

		public Command ShowGroupMembersMapCommand {
			get {
				return _showGroupMembersMapCommand ?? (_showGroupMembersMapCommand = new Command (async () => await ShowGroupMembersMapAsync ()));
			}
		}

		async Task ShowGroupMembersMapAsync ()
		{
			await navigation.PushAsync (new GroupMembersMapPage (new GeoLocation {
				Latitude = forecast.Location.Latitude,
				Longitude = forecast.Location.Longitude
			}));
		}
	}
}