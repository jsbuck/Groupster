using System;
using Groupster.Core;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Geolocation;

namespace Groupster.Core.Services
{
	public interface IOpenGroupMapService
	{
		Task<OpenGroupForecast> Get7DayForecastAsync (Position location);
	}

}