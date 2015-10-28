using System;
using System.Linq;
using System.Collections.Generic;

using Mono.Data.Sqlite;
using System.IO;
using System.Data;

namespace Groupster.Core
{
	/// <summary>
	/// GroupsterDatabase uses ADO.NET to create the [Items] table and create,read,update,delete data
	/// </summary>
	public class GroupsterDatabase 
	{
		static object locker = new object ();

		public SqliteConnection connection;

		public string path;

		/// <summary>
		/// Initializes a new instance of the <see cref="Groupster.DL.GroupsterDatabase"/> GroupsterDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		public GroupsterDatabase (string dbPath) 
		{
			var output = "";
			path = dbPath;

			// create the tables
			bool exists = File.Exists (dbPath);

			// Build list of data entities.
			List<IDataEntity> createEntities;
			var entities = new List<IDataEntity>() { new User(), new Group() };

			connection.Open ();
			if (exists) {
				createEntities = entities.Where (e => e.TableExists (connection) == false);
			} else {
				createEntities = entities;
			}

			// Create tables as needed.
			if(createEntities.Count() > 0) {
				foreach (var entity in createEntities) {
					using (var c = connection.CreateCommand ()) {
						c.CommandText = entity.CreateCommand;
						var i = c.ExecuteNonQuery ();
					}
				}
			}

			/*
			if (!exists) {
				connection = new SqliteConnection ("Data Source=" + dbPath);

				var commands = new[] {
					"CREATE TABLE [Users] (UserId INTEGER PRIMARY KEY ASC, Name TEXT, Gender TEXT, LoginId TEXT, Password TEXT, Biography TEXT, PrivacyCode TEXT, ImageFile TEXT, LocationId INTEGER);",
					"CREATE TABLE [Groups] (GroupId INTEGER PRIMARY KEY ASC, Name TEXT, StartOn TEXT, EndOn TEXT, Biography TEXT, PrivacyCode TEXT, ImageFile TEXT, LocationId INTEGER);",
					"CREATE TABLE [GroupUsers] (GroupUserId INTEGER PRIMARY KEY ASC, GroupId INTEGER, UserId INTEGER, StatusCode TEXT);",
					"CREATE TABLE [Locations] (LocationId INTEGER PRIMARY KEY ASC, Latitude REAL, Longitude REAL);",
					"CREATE TABLE [Messages] (MessageId INTEGER PRIMARY KEY ASC, GroupId INTEGER, UserId INTEGER, Sent TEXT, MessageContent TEXT);",
					"CREATE TABLE [GroupMessages] (GroupMessageId INTEGER PRIMARY KEY ASC, GroupId INTEGER, MessageId INTEGER, StatusCode TEXT);"
				};
				connection.Open ();
				foreach (var entity in entities) {
					using (var c = connection.CreateCommand ()) {
						c.CommandText = entity.CreateCommand;
						var i = c.ExecuteNonQuery ();
					}
				}
			} else {
				// already exists, determine if we need to update with any schema changes. 
				Console.WriteLine (output);
			}*/
		}

		/// <summary>Convert from DataReader to Task object</summary>
		Task FromReader (SqliteDataReader r) {
			var t = new Task ();
			t.ID = Convert.ToInt32 (r ["_id"]);
			t.Name = r ["Name"].ToString ();
			t.Notes = r ["Notes"].ToString ();
			t.Done = Convert.ToInt32 (r ["Done"]) == 1 ? true : false;
			return t;
		}

		public IEnumerable<Task> GetItems ()
		{
			var tl = new List<Task> ();

			lock (locker) {
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var contents = connection.CreateCommand ()) {
					contents.CommandText = "SELECT [_id], [Name], [Notes], [Done] from [Items]";
					var r = contents.ExecuteReader ();
					while (r.Read ()) {
						tl.Add (FromReader(r));
					}
				}
				connection.Close ();
			}
			return tl;
		}

		public Task GetItem (int id) 
		{
			var t = new Task ();
			lock (locker) {
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var command = connection.CreateCommand ()) {
					command.CommandText = "SELECT [_id], [Name], [Notes], [Done] from [Items] WHERE [_id] = ?";
					command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = id });
					var r = command.ExecuteReader ();
					while (r.Read ()) {
						t = FromReader (r);
						break;
					}
				}
				connection.Close ();
			}
			return t;
		}

		public int SaveItem (Task item) 
		{
			int r;
			lock (locker) {
				if (item.ID != 0) {
					connection = new SqliteConnection ("Data Source=" + path);
					connection.Open ();
					using (var command = connection.CreateCommand ()) {
						command.CommandText = "UPDATE [Items] SET [Name] = ?, [Notes] = ?, [Done] = ? WHERE [_id] = ?;";
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Name });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Notes });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Done });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.ID });
						r = command.ExecuteNonQuery ();
					}
					connection.Close ();
					return r;
				} else {
					connection = new SqliteConnection ("Data Source=" + path);
					connection.Open ();
					using (var command = connection.CreateCommand ()) {
						command.CommandText = "INSERT INTO [Items] ([Name], [Notes], [Done]) VALUES (? ,?, ?)";
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Name });
						command.Parameters.Add (new SqliteParameter (DbType.String) { Value = item.Notes });
						command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = item.Done });
						r = command.ExecuteNonQuery ();
					}
					connection.Close ();
					return r;
				}

			}
		}

		public int DeleteItem(int id) 
		{
			lock (locker) {
				int r;
				connection = new SqliteConnection ("Data Source=" + path);
				connection.Open ();
				using (var command = connection.CreateCommand ()) {
					command.CommandText = "DELETE FROM [Items] WHERE [_id] = ?;";
					command.Parameters.Add (new SqliteParameter (DbType.Int32) { Value = id});
					r = command.ExecuteNonQuery ();
				}
				connection.Close ();
				return r;
			}
		}
	}
}