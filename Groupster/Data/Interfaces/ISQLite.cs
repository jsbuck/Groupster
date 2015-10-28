using System;
using SQLite;

namespace Groupster.Core
{
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}
}

