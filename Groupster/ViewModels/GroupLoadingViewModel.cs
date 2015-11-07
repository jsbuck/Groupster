using System;
using Groupster.Core.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using XLabs.Platform.Services.Geolocation;
using System.Threading;

namespace Groupster.Core
{
	public class GroupLoadingViewModel : BaseViewModel
	{
		public GroupLoadingViewModel (INavigation navigation, IEnumerable<Group> groups, RootPage rootPage)
		{
			this.rootPage = rootPage;
			_navigation = navigation;
			_groups = groups;

			LoadingImage = "Radar.png";
			IsRefreshButtonVisible = false;
			IsActivityIndicatorVisible = false;

			Setup ();

		}

		RootPage rootPage;
		INavigation _navigation;
		IEnumerable<Group> _groups;

		void Setup ()
		{
		}

		private string _statusMessage;

		public string StatusMessage {
			get { return _statusMessage; }
			set { ChangeAndNotify (ref _statusMessage, value); }
		}


		private string _loadingImage;

		public string LoadingImage {
			get { return _loadingImage; }
			set { ChangeAndNotify (ref _loadingImage, value); }
		}

		//public Forecast Forecast{ get; set; }

		private Command _getGroupCommand;

		public Command GetGroupCommand {
			get {
				return _getGroupCommand ?? (_getGroupCommand = new Command (async () => await GetGroupsAsync () ));
			}
		}

		private bool _isRefreshButtonVisible;

		public bool IsRefreshButtonVisible {
			get { return _isRefreshButtonVisible; }
			set { ChangeAndNotify (ref _isRefreshButtonVisible, value); }
		}

		private bool _isActivityIndicatorVisible;

		public bool IsActivityIndicatorVisible {
			get { return _isActivityIndicatorVisible; }
			set { ChangeAndNotify (ref _isActivityIndicatorVisible, value); }
		}

		public async Task GetGroupsAsync ()
		{
		}
	}
}