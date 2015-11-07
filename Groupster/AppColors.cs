using Xamarin.Forms;

namespace Groupster.Core
{
	public static class AppColors
	{
		public static Color DarkText = Color.Black;
		public static Color BaseColor = Color.FromHex ("0F7800"); // Dark Green
		public static Color PositiveBackground = Color.FromRgb(200, 200, 200);
		public static Color NegativeBackground = Color.FromHsla(Color.Red.Hue, 1.0, 0.75);
		public static Color BackgroundGrey = Color.FromRgb(200, 200, 200);
		public static Color PositiveBalance = Color.FromRgb(37, 64, 33);
		public static Color NegativeBalance = Color.FromRgb(159, 15, 51);
		public static Color LightBlue = Color.FromRgb(52, 152, 219);
		public static Color SubTitle = Color.FromRgb(52, 152, 219);
		public static Color Button = Color.FromHex("0C5A00");

		static AppColors()
		{
			Device.OnPlatform(
				Android: () =>{
					PositiveBalance = PositiveBalance.AddLuminosity(0.3);
					NegativeBalance = NegativeBalance.AddLuminosity(0.3);
					SubTitle = Color.FromRgb(115, 129, 130);
				},
				WinPhone: () =>{
					PositiveBalance = PositiveBalance.AddLuminosity(0.3);
					NegativeBalance = NegativeBalance.AddLuminosity(0.3);
				}
			);
		}
	}
}
