using System;
using SQLite;

namespace Groupster.Core
{
	[Table("GroupUsers")]
	public class GroupUser : DataEntityBase
	{
		int _groupID;
		int _userID;
		string _statusCode;

		public GroupUser ()
		{
			_tableName = "GroupUsers";
		}


		public int GroupID {
			get {
				return _groupID;
			}
			set {
				_groupID = value;
			}
		}

		public int UserID {
			get {
				return _userID;
			}
			set {
				_userID = value;
			}
		}

		public string StatusCode {
			get {
				return _statusCode;
			}
			set {
				_statusCode = value;
			}
		}

	}
}

