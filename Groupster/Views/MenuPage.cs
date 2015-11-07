using Xamarin.Forms;
using System.Collections.Generic;

namespace Groupster.Core
{
	public class MenuPage : ContentPage
	{
		readonly List<OptionItem> OptionItems = new List<OptionItem> ();

		public ListView Menu { get; set; }

		public MenuPage ()
		{
			this.BackgroundColor = Color.FromHex ("232323");

			OptionItems.Add (new EventOptionItem ());

			var stackLayout = new StackLayout {
				Spacing = 5,
				VerticalOptions = LayoutOptions.FillAndExpand,

			};

			var headerLabel = new Label {
				TextColor = Color.FromHex ("838383"),
				BackgroundColor = Color.FromHex ("474646"),
				Text = "BROWSE", 
			};

			Device.OnPlatform (iOS: () => headerLabel.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				Android: () => headerLabel.FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)));

			var headerContentView = new ContentView {
				Content = headerLabel
			};

			Menu = new ListView {
				ItemsSource = OptionItems,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "Title");
			cell.SetBinding (ImageCell.ImageSourceProperty, "IconSource");

			Menu.ItemTemplate = cell;

			stackLayout.Children.Add (headerContentView);
			stackLayout.Children.Add (Menu);

			Content = stackLayout;
		}
	}

}


