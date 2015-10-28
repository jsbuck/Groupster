using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Groupster.Core
{
	[Table("Groups")]
	public class Group : DataEntityBase, IProfile
	{
		string _name;
		string _biography;
		string _privacyCode;
		string _imageFile;
		int _locationId;
		DateTime _startOn = DateTime.Now.AddHours (1); // default to one hour from now.
		DateTime _endOn = DateTime.Now.AddHours(1); // default duration to one hour.

		List<GroupUser> _groupUsers;

		public Group ()
		{
			_tableName = "Groups";
			_createCommand = "CREATE TABLE [Groups] (GroupId INTEGER PRIMARY KEY ASC, Name TEXT, StartOn TEXT, EndOn TEXT, Biography TEXT, PrivacyCode TEXT, ImageFile TEXT, LocationId INTEGER);";
		}

		public string Name { 
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public string Biography {
			get {
				return _biography;
			}
			set {
				_biography = value;
			}
		}

		public string PrivacyCode {
			get {
				return _privacyCode;
			}
			set {
				_privacyCode = value;
			}
		}

		public string ImageFile {
			get {
				return _imageFile;
			}
			set {
				_imageFile = value;
			}
		}

		public int LocationID {
			get {
				return _locationId;
			}
			set {
				_locationId = value;
			}
		}

		[Ignore]
		public GroupStatus Status {
			get {
				return calcGroupStatus ();
			}
		}

		[Ignore]
		public List<GroupUser> GroupUsers {
			get { 
				return _groupUsers;
			}
		}

		private GroupStatus calcGroupStatus() {
			DateTime current = DateTime.Now;

			if (current < _startOn) {
				return GroupStatus.Pending;
			} else if (current > _endOn) {
				return GroupStatus.Expired;
			} else {
				return GroupStatus.Active;
			}
		}

	}

	public enum GroupStatus{
		Pending,
		Active,
		Expired
	}

}

