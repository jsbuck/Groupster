using System;
using System.Collections.Generic;
using Xamarin.Forms.Labs.Services.Geolocation;

namespace Groupster.Core
{
	public class Forecast
	{
		private List<GroupViewTemplate> _groupList;

		public int ScheduledGroupsCount { get; set; }

		public List<GroupViewTemplate> GroupList {
			get {
				if (_groupList == null) {
					_groupList = new List<GroupViewTemplate> ();
				}

				return _groupList;
			}
			set { _groupList = value; }
		}

		public string Reason { get; set; }

		public DateTime BadWeatherDay { get; set; }

		public string ReasonDescription { get; set; }

		public Position Location { get; set; }
	}
}
