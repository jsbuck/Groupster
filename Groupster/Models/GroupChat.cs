using System;
using SQLite;

namespace Groupster.Core
{
	[Table("GroupChats")]
	public class GroupChat : DataEntityBase
	{
		int _userID;
		int _groupID;
		int _messageID;

		public GroupChat ()
		{
			_tableName = "GroupChats";
		}

		public int UserID {
			get {
				return _userID;
			}
			set {
				_userID = value;
			}
		}

		public int GroupID {
			get {
				return _groupID;
			}
			set {
				_groupID = value;
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

