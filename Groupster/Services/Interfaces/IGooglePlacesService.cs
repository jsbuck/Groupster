using System.Collections.Generic;
using System.Threading.Tasks;

namespace Groupster.Core
{
	public interface IGooglePlacesService
	{
		Task<List<Place>> GetGroupMembersAsync (GeoLocation location);
	}
}