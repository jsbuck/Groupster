using System;
using System.Collections.Generic;
using SQLite;

namespace Groupster.Core
{
	public class DataEntityBase : IDataEntity
	{
		protected int _id;
		protected string _tableName;
		protected string _createCommand;
		protected string _insertCommand;
		protected string _deleteCommand;
		protected string _updateCommand;

		public DataEntityBase ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID {
			get {
				return _id;
			}
			set {
				_id = value; 
			}
		}

		#region IDataEntity implementation

		public string TableName {
			get {
				return _tableName;
			}
		}

		public string CreateCommand {
			get {
				return _createCommand;
			}
		}

		public string InsertCommand {
			get {
				return _insertCommand;
			}
		}

		public string DeleteCommand {
			get {
				return _deleteCommand;
			}
		}

		public string UpdateCommand {
			get {
				return _updateCommand;
			}
		}

		#endregion
	}
}

