using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Groupster.Core
{
	public class GroupMembersMapViewModel
	{
		public GroupMembersMapViewModel (IGooglePlacesService googlePlacesService,
		                              GeoLocation currentPosition)
		{
			_googlePlacesService = googlePlacesService;
			_currentPosition = currentPosition;
		}

		private readonly IGooglePlacesService _googlePlacesService;
		private readonly GeoLocation _currentPosition;


		public async Task<List<CustomPin>> GetMapPinsAsync ()
		{
			var groupMemberPins = new List<CustomPin> ();

			var groupMembers = await _googlePlacesService.GetGroupMembersAsync (_currentPosition);

			foreach (var member in groupMembers) {
				var groupMemberPin = new CustomPin {
					Position = new Position (member.geometry.location.lat, member.geometry.location.lng),
					Label = member.name,
					Address = member.vicinity,
					PinIcon = "CarWashMapIcon"
				};

				groupMemberPins.Add (groupMemberPin);
			}

			return groupMemberPins;
		}
	}
}