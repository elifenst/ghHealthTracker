using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Foundation;
using UIKit;
using GloomHavenHealthTracker.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace GloomHavenHealthTracker.iOS
{
	public class DatabaseConnection_iOS: IDatabaseConnection
	{
		public SQLiteConnection DBConnection()
		{
			var path = "asdf";
			return new SQLiteConnection(path);
		}
	}
}