using System;
using Groupster.Core;
using System.Net.Http;
using Groupster;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Geolocation;

namespace Groupster.Core.Services
{
	public class OpenGroupMapService : IOpenGroupMapService
	{
		public OpenGroupMapService (HttpClient restClient)
		{
			_restClient = restClient;
		}

		private readonly HttpClient _restClient;

		private const string API_KEY = "f1b95129238500926b4806dfdee9a05a";

		private const string OpenGroupApiUrl =
			"http://api.openweathermap.org/data/2.5/forecast/daily?lat={0}&lon={1}&cnt=7&mode=json&units=imperial&APPID={2}";

		public async Task<OpenGroupForecast> Get7DayForecastAsync (Position location)
		{
			var uri = string.Format (OpenGroupApiUrl, location.Latitude,
				          location.Longitude, API_KEY);

			var result = await _restClient.GetAsync<OpenGroupForecast> (uri);

			return result;
		}

	}
}