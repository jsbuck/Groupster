using Xamarin.Forms;

namespace Groupster.Core
{
	/// <summary>
	///   This class is a ViewCell that will be displayed for each employee.
	/// </summary>
	class UserCell : ViewCell
	{
		public UserCell()
		{
			StackLayout nameLayout = CreateNameLayout();
			Image image = CreateGroupImageLayout;

			StackLayout viewLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = { image, nameLayout }
			};
			View = viewLayout;
		}

		/// <summary>
		///   Create a Xamarin.Forms image and bind it to the ImageUri property.
		/// </summary>
		/// <value>The create employee image layout.</value>
		static Image CreateGroupImageLayout
		{
			get
			{
				Image image = new Image
				{
					HorizontalOptions = LayoutOptions.Start
				};
				image.SetBinding(Image.SourceProperty, new Binding("ImageFile"));
				image.WidthRequest = image.HeightRequest = 40;
				return image;
			}
		}

		/// <summary>
		///   Create a layout to hold the name & twitter handle of the user.
		/// </summary>
		/// <returns>The name layout.</returns>
		static StackLayout CreateNameLayout()
		{
			#region Create a Label for name
			Label nameLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "Name");
			#endregion

			#region Create a label for the Twitter handler.
			Label genderLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = Fonts.Twitter.FontFamily,
				FontSize = Fonts.Twitter.FontSize,
				FontAttributes = Fonts.Twitter.FontAttributes
			};
			genderLabel.SetBinding(Label.TextProperty, "Gender");
			#endregion

			StackLayout nameLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, genderLabel }
			};
			return nameLayout;
		}
	}
}
