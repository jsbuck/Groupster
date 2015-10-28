using System;
using SQLite;

namespace Groupster.Core
{
	public interface IDataEntity
	{
		int ID { get; set; }
		string TableName { get; }
		string CreateCommand { get; }
		string InsertCommand { get; }
		string DeleteCommand { get; }
		string UpdateCommand { get; }

		//bool TableExists(SQLiteConnection db);

	}
}

