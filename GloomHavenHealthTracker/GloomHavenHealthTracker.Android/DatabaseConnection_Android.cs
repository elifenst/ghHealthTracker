using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GloomHavenHealthTracker.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace GloomHavenHealthTracker.Droid
{
	public class DatabaseConnection_Android:IDatabaseConnection
	{
		public SQLiteConnection DBConnection()
		{
			var dbName = "GloomHavenDB.db";
			return new SQLiteConnection(dbName);
		}

	}
}