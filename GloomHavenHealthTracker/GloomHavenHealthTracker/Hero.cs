using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLitePCL;
using System.Windows;
using PCLStorage;
using Xamarin.Forms.PlatformConfiguration;
using SQLite;


namespace GloomHavenHealthTracker
{
	[Table("Hero")]
	public class Hero
	{

		public event PropertyChangedEventHandler PropertyChanged;
		private int _experience;
		[NotNull]
		public int Experience
		{
			get
			{
				return _experience;
			}
			set
			{
				_experience = value;
				
				//Now call the propertychanged for Level, NextLevel, and Experience
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Experience"));

			}
		}
		public int Gold { get; set; }
		private int _heroID;
		[PrimaryKey, AutoIncrement]
		public int HeroID
		{
			get
			{
				return _heroID;
			}

			set
			{
				_heroID = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HeroID"));
			}
		}
		private string _name;
		[NotNull, MaxLength(50)]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Level"));
			}
		}
		private string _class;
		[NotNull, MaxLength(50)]
		public string Class
		{
			get
			{
				return _class;
			}
			set
			{
				_class = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Class"));
			}
		}
		private bool _isRetired;
		public bool IsRetired
		{
			get
			{
				return _isRetired;
			}
			set
			{
				_isRetired = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRetired"));
			}
		}
	}
}