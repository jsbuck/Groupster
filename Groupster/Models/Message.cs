using System;
using SQLite;

namespace Groupster.Core
{
	[Table("Messages")]
	public class Message : DataEntityBase
	{
		string _messageBody;
		DateTime _sent;
		int _sentByUserID;
		bool _read;

		public Message ()
		{
			_tableName = "Messages";
		}

		public int SentByUserID {
			get {
				return _sentByUserID;
			}
			set {
				_sentByUserID = value;
			}
		}

		public string MessageBody {
			get {
				return _messageBody;
			}
			set {
				_messageBody = value;
			}
		}

		public DateTime Sent {
			get {
				return _sent;
			}
			set {
				_sent = value;
			}
		}

		public bool Read {
			get {
				return _read;
			}
			set {
				_read = value;
			}
		}

	}
}

