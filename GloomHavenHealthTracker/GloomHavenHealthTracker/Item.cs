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
	[Table("Item")]
    public class Item
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private int _itemPK;
		[PrimaryKey, AutoIncrement]
		public int ItemPK
		{
			get
			{
				return _itemPK;
			}
			set
			{
				_itemPK = value;
			}
		}
		private string _name;
		[MaxLength(50), NotNull]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		private int _itemID;
		[NotNull]
		public int ID
		{
			get
			{
				return _itemID;
			}
			set
			{
				_itemID = value;
			}
		}
		private string _effects;
		[MaxLength(50)]
		public string Effects
		{
			get
			{
				return _effects;
			}
			set
			{
				_effects = value;
			}
		}
		private int _cost;
		public int Cost
		{
			get
			{
				return _cost;
			}
			set
			{
				_cost = value;
			}
		}
		private int _itemHeroFK;
		[NotNull]
		public int ItemHeroFK
		{
			get
			{
				return _itemHeroFK;
			}
			set
			{
				_itemHeroFK = value;
			}
		}
	}
	

}
