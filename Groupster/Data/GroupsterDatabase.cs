using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Groupster.Core
{
	public class GroupsterDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Groupster.DL.GroupsterDatabase"/> GroupsterDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public GroupsterDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();

			// create the tables
			database.CreateTable<User>();
			database.CreateTable<Group>();
			database.CreateTable<GroupUser>();
		}


		public IEnumerable<T> GetItems<T> () where T : new()
		{
			lock (locker) {
				return (from i in database.Table<T>() select i).ToList();
			}
		}
		/*
		public IEnumerable<TodoItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
			}
		}
*/

		public T GetItem<T> (int id) where T : DataEntityBase, new() 
		{
			lock (locker) {
				return database.Table<T>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem<T> (T item) where T : DataEntityBase, new()
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem<T>(int id)
		{
			lock (locker) {
				return database.Delete<T>(id);
			}
		}

	}
}

