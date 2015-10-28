using System;

namespace Groupster.Core
{
	public interface IProfile
	{
		string Name { get; set; }
		string Biography { get; set; }
		string PrivacyCode { get; set; }
		string ImageFile { get; set; }
		int LocationID { get; set; }
	}
}

