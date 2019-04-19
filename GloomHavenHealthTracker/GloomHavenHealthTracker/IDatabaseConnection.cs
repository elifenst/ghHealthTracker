using System;
using System.Collections.Generic;
using System.Text;

namespace GloomHavenHealthTracker
{
	public interface IDatabaseConnection
	{
		SQLite.SQLiteConnection DBConnection();
	}
}
