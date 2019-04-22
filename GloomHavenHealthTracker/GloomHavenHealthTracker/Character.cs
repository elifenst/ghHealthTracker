using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLitePCL;
using System.Windows;
using PCLStorage;
using Xamarin.Forms.PlatformConfiguration;
using SQLite;
using System.Collections.Generic;

namespace GloomHavenHealthTracker
{
	public class Character:INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private ObservableCollection<PerkWrapper> _perks;
		public ObservableCollection<PerkWrapper> Perks
		{
			get
			{
				return _perks;
			}
			set
			{
				_perks = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Perks"));
			}
		}
		private ObservableCollection<Item> _items;
		public ObservableCollection<Item> Items
		{
			get
			{
				return _items;
			}
			set
			{
				_items = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
			}
		}
		public int Level { get; set; }
		private int _experience;
		public Hero hero;
		public int Experience
		{
			get
			{
				return _experience;
			}
			set
			{
				_experience = value;
				//Update level
				if (_experience < 45)
				{
					Level = 1;
				}
				else if (_experience < 95)
				{
					Level = 2;
				}
				else if (_experience < 150)
				{
					Level = 3;
				}
				else if (_experience < 210)
				{
					Level = 4;
				}
				else if (_experience < 275)
				{
					Level = 5;
				}
				else if (_experience < 345)
				{
					Level = 6;
				}
				else if (_experience < 420)
				{
					Level = 7;
				}
				else if (_experience < 500)
				{
					Level = 8;
				}
				else
				{
					Level = 9;
				}
				//Now call the propertychanged for Level, NextLevel, and Experience
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Level"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NextLevel"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Experience"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progress"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClassLvl"));

				//Change it in the hero
				hero.Experience = value;
				//Now set it in database
				myCharacterVM.SaveCharacter(this);
			}
		}
		public string ExperienceDisplay
		{
			get
			{
				return "Experience: " + Experience;
			}
		}
		public int NextLevel
		{
			get
			{
				return Level + 1;
			}
		}
		public string Progress
		{
			get
			{
				double LvlXP = 2.5 * Level *Level + 75 * Level / 2 - 40;
				double NextLvlXp = 2.5 * (Level+1) * (Level +1)+ 75 * (Level+1) / 2 - 40;
				double result = (Experience - LvlXP) / ( NextLvlXp-LvlXP);
				System.Diagnostics.Debug.WriteLine(result);
				return result.ToString();

			}
		}
		public int Gold { get; set; }
		private int _heroID;
		public CharacterVM myCharacterVM { get; set; }
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
		public string ClassLvl
		{
			get
			{
				return "Level " + Level + " " + Class;
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
		public Character (Hero hero1, List<Item> items, List<PerkWrapper> perks, CharacterVM charVM)
		{
			Items = new ObservableCollection<Item>();
			Perks = new ObservableCollection<PerkWrapper>();
			this.hero = hero1;
			myCharacterVM = charVM;
			Name = hero.Name;
			Gold = hero.Gold;
			Experience = hero.Experience;
			HeroID = hero.HeroID;
			Class = hero.Class;
			foreach (var item in items)
				Items.Add(item);
			foreach (var perk in perks)
				Perks.Add(perk);
		}

	}
}