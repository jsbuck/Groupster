using System;
using Xamarin.Forms;
using Groupster.Core;
using Xamarin.Forms.Labs.Controls;

namespace Groupster.Core
{
	public class ForecastPage : ContentPage
	{

		public ForecastPage (RootPage rootPage, Forecast forecast)
		{
			this._rootPage = rootPage;
			_forecast = forecast;
			BindingContext = new ForecastViewModel (Navigation, _forecast);

			NavigationPage.SetHasNavigationBar (this, false);

			var masterGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition{ Height = new GridLength (0.3, GridUnitType.Star) },
					new RowDefinition{ Height = new GridLength (0.3, GridUnitType.Star) },
					new RowDefinition{ Height = new GridLength (0.4, GridUnitType.Star) }
				},
				ColumnDefinitions = new ColumnDefinitionCollection{ new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) } }
			};

			var forecastListview = new ListView ();

			var forecastListviewItemTemplate = new DataTemplate (typeof(ImageCell));

			forecastListviewItemTemplate.SetBinding (ImageCell.TextProperty, "ItemTemplateTextProperty");
      		forecastListviewItemTemplate.SetValue(ImageCell.TextColorProperty, Color.FromHex("#3498DB"));
			forecastListviewItemTemplate.SetBinding (ImageCell.DetailProperty, "ItemTemplateDetailProperty");
      		forecastListviewItemTemplate.SetValue(ImageCell.DetailColorProperty, Color.White);
			forecastListviewItemTemplate.SetBinding (ImageCell.ImageSourceProperty, "Icon");

			forecastListview.ItemTemplate = forecastListviewItemTemplate;
			forecastListview.SetBinding<ForecastViewModel> (ListView.ItemsSourceProperty, vm => vm.GroupList);

			var refreshImage = new ImageButton () {
				Image = "Refresh",
				ImageHeightRequest = 70,
				ImageWidthRequest = 70,
        		BorderColor = Color.Transparent,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Transparent
			};

			refreshImage.Clicked += (object sender, EventArgs e) => {
				/*_rootPage.ShowLoadingDialogAsync ();*/
			};

			var topGrid = new Grid {RowDefinitions = new RowDefinitionCollection {
					new RowDefinition{ Height = new GridLength (1, GridUnitType.Star) }
				},
				ColumnDefinitions = new ColumnDefinitionCollection { 
					new ColumnDefinition{ Width = new GridLength (0.8, GridUnitType.Star) },
					new ColumnDefinition{ Width = new GridLength (0.2, GridUnitType.Star) },
				}
			};

			topGrid.Children.Add (CreateForecastStatusStackLayout (), 0, 0);
			topGrid.Children.Add (refreshImage, 1, 0);

			masterGrid.Children.Add (topGrid, 0, 0);
			masterGrid.Children.Add (CreateMiddleStackLayout (), 0, 1);
			masterGrid.Children.Add (forecastListview, 0, 2);

			Content = masterGrid;
		}

		RootPage _rootPage;
		private Forecast _forecast;

		StackLayout CreateForecastStatusStackLayout ()
		{
			var scheduledGroupsLabel = new ExtraLargeLabel { HorizontalOptions = LayoutOptions.Center };
			
			scheduledGroupsLabel.SetBinding<ForecastViewModel> (Label.TextProperty, vm => vm.ScheduledGroupCount);
			scheduledGroupsLabel.TextColor = GetScheduledGroupsTextColor (_forecast.ScheduledGroupsCount);

			var scheduledGroupsTextLabel = new LargeLabel { VerticalOptions = LayoutOptions.CenterAndExpand };
			scheduledGroupsTextLabel.SetBinding<ForecastViewModel> (Label.TextProperty, vm => vm.ScheduledGroupText);

			var horizontalStackLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Start,
				Padding = new Thickness (40, 0, 0, 0)
			};


			horizontalStackLayout.Children.Add (new LargeLabel {
				Text = "Events for ",
				VerticalOptions = LayoutOptions.CenterAndExpand
			});
			horizontalStackLayout.Children.Add (scheduledGroupsLabel);
			horizontalStackLayout.Children.Add (scheduledGroupsTextLabel);

			return horizontalStackLayout;
		}

		/// <summary>
		/// Return different text color based 
		/// on how many days the car is going to stay clean
		/// </summary>
		/// <param name="daysClean"></param>
		/// <returns></returns>
		private Color GetScheduledGroupsTextColor (int groupCount)
		{
			//Colors from : http://www.flatuicolorpicker.com/
			switch (groupCount) {
			case 0:
			case 1:
          		//Thunderbird(red)
				return Color.FromHex ("#D91E18");
			case 2:
          		//ripe lemon(yellow)
				return Color.FromHex ("#F7CA18");
			default :
          		//Eucalyptus(green)
				return Color.FromHex ("#26A65B");
			}
		}

		StackLayout CreateMiddleStackLayout ()
		{
			var stackLayout = new StackLayout{ };

			var carWashButton = new Button {
				Text = "Show Car Washes",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			carWashButton.SetBinding<ForecastViewModel> (Button.CommandProperty, vm => vm.ShowGroupMembersMapCommand);

			var carImage = new Image {
				Source = "CarSideView.png",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Start
			};


			stackLayout.Children.Add (carWashButton);
			stackLayout.Children.Add (carImage);

			return stackLayout;
		}
	}
}