using System.ComponentModel;
using SQLitePCL;
using System.Windows;
using PCLStorage;
using Xamarin.Forms.PlatformConfiguration;
using SQLite;

namespace GloomHavenHealthTracker
{
	[Table("Perk")]
    public class Perk
    {
		[PrimaryKey, AutoIncrement]
		public int PerkPK { get; set; }
		[NotNull]
		public int PerkHeroFK { get; set; }
		[NotNull]
		public int Taken { get; set; }
		[NotNull, MaxLength(50)]
		public string Effect { get; set; }
    }
}
