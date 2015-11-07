using System;
using Xamarin.Forms;
using Groupster.Core.Services;
using System.Net.Http;

namespace Groupster.Core
{
	public class GroupPage : ContentPage
	{
		public GroupPage (RootPage rootPage)
		{
			_rootPage = rootPage;
			NavigationPage.SetHasNavigationBar (this, false);

			//TODO : Inject Groups
			_db = new GroupsterDatabase();

			_viewModel = new GroupLoadingViewModel (Navigation, _db.GetItems<Group>(), rootPage);
			BindingContext = _viewModel;

			var statusMessageLabel = new LargeLabel {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.White,
			};

			statusMessageLabel.SetBinding<GroupLoadingViewModel> (Label.TextProperty, vm => vm.StatusMessage);

			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Spacing = 10
			};

			var loadingImage = new Image ();

			loadingImage.SetBinding<GroupLoadingViewModel> (Image.SourceProperty, vm => vm.LoadingImage);

			var refreshButton = new Button{ Text = "Refresh", HorizontalOptions = LayoutOptions.Center };

			refreshButton.SetBinding<GroupLoadingViewModel> (Button.CommandProperty, vm => vm.GetGroupCommand);
			refreshButton.SetBinding<GroupLoadingViewModel> (VisualElement.IsVisibleProperty, vm => vm.IsRefreshButtonVisible);

			var activityIndicator = new ActivityIndicator{ IsRunning = true };

			activityIndicator.SetBinding<GroupLoadingViewModel> (VisualElement.IsVisibleProperty, vm => vm.IsActivityIndicatorVisible);

			stackLayout.Children.Add (loadingImage);
			stackLayout.Children.Add (statusMessageLabel);
			stackLayout.Children.Add (activityIndicator); 	
			stackLayout.Children.Add (refreshButton);

			Content = stackLayout;
		}

		RootPage _rootPage {
			get;
			set;
		}

		GroupLoadingViewModel _viewModel {
			get;
			set;
		}

		GroupsterDatabase _db {
			get;
			set;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			//_rootPage.NavigateTo (new EventOptionItem (), _viewModel.Forecast);
		}

	}
}

