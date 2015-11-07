using System;
using SQLite;

namespace Groupster.Core
{
	[Table("UserChats")]
	public class UserChat : DataEntityBase
	{
		int _userID;
		int _messageID;

		public UserChat ()
		{
			_tableName = "UserChats";
		}

		public int UserID {
			get {
				return _userID;
			}
			set {
				_userID = value;
			}
		}

		public int MessageID {
			get {
				return _messageID;
			}
			set {
				_messageID = value;
			}
		}

	}
}

