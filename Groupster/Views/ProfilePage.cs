using System;
using Xamarin.Forms;

namespace Groupster.Core
{
	public class ProfilePage : BaseContentPage
	{
		public ProfilePage () {
			Content = new LargeLabel () {
				Text = "Profile Page",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}
}

