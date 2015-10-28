using System;
using SQLite;

namespace Groupster.Core 
{
	/// <summary>
	/// User business object
	/// </summary>
	[Table("Users")]
	public class User : DataEntityBase, IProfile
	{
		string _name;
		string _gender;
		string _loginId;
		string _password;
		string _biography;
		string _privacyCode;
		string _imageFile;
		int _locationId;

		public User ()
		{
			_tableName = "Users";
			_createCommand = "CREATE TABLE [Users] (UserId INTEGER PRIMARY KEY ASC, Name TEXT, Gender TEXT, LoginId TEXT, Password TEXT, Biography TEXT, PrivacyCode TEXT, ImageFile TEXT, LocationId INTEGER);";
		}

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		public string Gender {
			get {
				return _gender;
			}
			set {
				_gender = value;
			}
		}

		public string LoginID {
			get {
				return _loginId;
			}
			set {
				_loginId = value;
			}
		}

		public string Password {
			get {
				return _password;
			}
			set {
				_password = value;
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

	}
}