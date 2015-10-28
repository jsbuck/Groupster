using System;
using Xamarin.Forms;

namespace Groupster.Core
{
	public class LargeLabel : Label
	{
		public LargeLabel ()
		{
			Font = Font.SystemFontOfSize (20);
			TextColor = Color.White;
		}
	}
}

