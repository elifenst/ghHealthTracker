using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace GloomHavenHealthTracker
{
	public class MonsterVM : INotifyPropertyChanged
	{
		private Monster lastDeletedMonster;
		public event PropertyChangedEventHandler PropertyChanged;
		private string _level;
		public string level
		{
			get
			{
				return _level;
			}
			set
			{
				_level = value;
				System.Diagnostics.Debug.WriteLine("new level: " + _level);
			}
		}
		private ObservableCollection<Monster> _Monsters;
		public ObservableCollection<Monster> Monsters
		{
			get
			{
				return _Monsters;
			}
			set
			{
				_Monsters = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
			}
		}
		public void add(Monster monster)
		{
			monster.monsterVM = this;
			_Monsters.Add(monster);
			this.sort();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));

		}
		public void remove(Monster monster)
		{
			lastDeletedMonster = monster;
			_Monsters.Remove(monster);
			PropertyChanged(this, new PropertyChangedEventArgs("Monsters"));
		}
		public void restore()
		{
			if (lastDeletedMonster != null)
			{
				if (lastDeletedMonster.currentHealth <= 0)
				{
					lastDeletedMonster.currentHealth = 1;
				}
				add(lastDeletedMonster);
				lastDeletedMonster = null;
			}
		}
		public void sort()
		{
			System.Diagnostics.Debug.WriteLine(_Monsters.Count);
			for (int ptr = 0; ptr < _Monsters.Count; ptr++)
			{
				//System.Diagnostics
				int currentLocation = 0;
				while 
					(currentLocation < ptr && 
						(string.Compare(_Monsters[ptr].Name, _Monsters[currentLocation].Name) > 0 
						)
					)
				{
					currentLocation++;
					System.Diagnostics.Debug.WriteLine("minus minus");
				}
				if (currentLocation >= 0)
				{
					_Monsters.Insert(currentLocation, _Monsters[ptr]);
					_Monsters.RemoveAt(ptr + 1);
				}
			}
			foreach (Monster asdf in _Monsters)
			{
				System.Diagnostics.Debug.WriteLine("Monsters: " + asdf.Name);
			}

		}

		public MonsterVM()
		{
			//SubtractHealthCommand = new Command(SubtractHealthExecute);
		}
	}
}
