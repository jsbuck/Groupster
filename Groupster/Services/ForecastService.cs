using System;
using System.Globalization;
using System.Linq;
using Groupster.Core;
using Groupster;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Geolocation;

namespace Groupster.Core.Services
{
	public class ForecastService : IForecastService
	{
		OpenGroupMapService _openGroupMapService {
			get;
			set;
		}

		public ForecastService (OpenGroupMapService openGroupMapService)
		{
			_openGroupMapService = openGroupMapService;
		}

		public async Task<Forecast> GetForecastAsync (Position location)
		{
			var openGroupForecast = await _openGroupMapService.Get7DayForecastAsync (location);
			var forecast = new Forecast () {
				Location = location
			};

			var daysClean = 0;
			var dtf = new DateTimeFormatInfo ();
			
			foreach (var forecastItem in openGroupForecast.Forecasts) {
				var weather = forecastItem.WeatherList.FirstOrDefault ();
				var date = new DateTime (1970, 1, 1).AddSeconds (forecastItem.Dt);
			
				forecast.GroupList.Add (new GroupViewTemplate {
					GroupCondition = weather.Description,
					DayAbbreviation = dtf.GetAbbreviatedDayName (date.DayOfWeek),
					EventStart = Convert.ToInt32(forecastItem.Temperature.Max) + "º",
					EventEnd = Convert.ToInt32(forecastItem.Temperature.Min) + "º",
					Icon = GetWeatherIcon (weather.Main)
				});
			
			}

			foreach (var forecastItem in openGroupForecast.Forecasts) {
				var date = new DateTime (1970, 1, 1).AddSeconds (forecastItem.Dt);
			
				if (date.Date.Date < DateTime.Now.Date.Date)
					continue;
			
				var weatherForToday = forecastItem.WeatherList [0];
			
				forecast.BadWeatherDay = date;
				forecast.Reason = ConvertReason (weatherForToday.Main);
				forecast.ReasonDescription = weatherForToday.Description;
			
				if (WeatherIsBad (weatherForToday))
					break;
			
				daysClean++;
			}
			
			forecast.ScheduledGroupsCount = daysClean;

			return forecast;
		}

		string GetWeatherIcon (string description)
		{
			var descriptionToLower = description.ToLower ();

			switch (descriptionToLower) {
			case "rain": 
				return "Rain.png";	
			case "clouds":
        		return "Cloud.png";
			case "snow":
        		return "Snow.png";
			case "clear":
        		return "Clear.png";
			}

			return string.Empty;
		}

		/// <summary>
		/// Convert the Service Weather Reason to a custom reason
		/// </summary>
		/// <param name="originalReason"></param>
		/// <returns></returns>
		private string ConvertReason (string originalReason)
		{
			//For testing purposes
			//return "Rain";
			//return "Snow";

			if (!string.IsNullOrEmpty (originalReason)) {
				switch (originalReason) {
				case "Clear":
					return string.Empty;
				}
			}

			return originalReason;
		}

		private bool WeatherIsBad (Weather weatherForToday)
		{
			if (weatherForToday.Main == "Rain" || weatherForToday.Main == "Snow") {
				return true;
			}

			return false;
		}
	}
}
