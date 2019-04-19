using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;
using GloomHavenHealthTracker.UWP;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]
namespace GloomHavenHealthTracker.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
		public SQLiteConnection DBConnection()
		{
			var dbName = "GloomHaveDB.db";
			var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
			return new SQLiteConnection(path);
		}
    }
}
