﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Groupster;

namespace Groupster.Core
{
	public class GooglePlacesService : IGooglePlacesService
	{
		public GooglePlacesService (HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		HttpClient _httpClient {
			get;
			set;
		}

		const string API_KEY = "AIzaSyDd8OZpkInkvX4VXQ8_6FS6_0ik78LrhA8";

		const string GooglePlacesUrl =
			"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=5000&sensor=true&name=car%wash&key={2}";

		public async Task<List<Place>> GetGroupMembersAsync (GeoLocation location)
		{
			var uri = string.Format (GooglePlacesUrl, location.Latitude,
				          location.Longitude, API_KEY);

			var result = await _httpClient.GetAsync<PlacesRootObject> (uri);

			return result.Places;
		}
	}
}

