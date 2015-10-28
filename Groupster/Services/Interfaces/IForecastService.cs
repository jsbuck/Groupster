using Groupster.Core;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Geolocation;

namespace Groupster.Core.Services
{
	public interface IForecastService
	{
		Task<Forecast> GetForecastAsync (Position location);
	}

}
