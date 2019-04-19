using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace GloomHavenHealthTracker
{

	public class Monster : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool _poisoned;
		public bool poisoned
		{
			get
			{
				return _poisoned;
			}
			set
			{
				_poisoned = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("poisoned"));
				}
				
			}
		}
		private bool _wounded;
		public bool wounded
		{
			get
			{
				return _wounded;
			}
			set
			{
				_wounded = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("wounded"));
				}
				
			}
		}
		private bool _crippled;
		public bool crippled
		{
			get
			{
				return _crippled;
			}
			set
			{
				_crippled = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("crippled"));
				}
			}
		}
		private bool _stunned;
		public bool stunned
		{
			get
			{
				return _stunned;
			}
			set
			{
				_stunned = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("stunned"));
				}
				
			}
		}
		private bool _confused;
		public bool confused
		{
			get
			{
				return _confused;
			}
			set
			{
				_confused = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("confused"));
				}
				
			}
		}
		private bool _disarmed;
		public bool disarmed
		{
			get
			{
				return _disarmed;
			}
			set
			{
				_disarmed = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("disarmed"));

			}
		}
		private bool _strong;
		public bool strong
		{
			get
			{
				return _strong;
			}
			set
			{
				_strong = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("strong"));
				}

			}
		}
		private bool _invisible;
		public bool invisible
		{
			get
			{
				return _invisible;
			}
			set
			{
				_invisible = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("invisible"));
				}

			}
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name + " " + Number;
			}
			set
			{
				_name = value;
			}

		}
		public MonsterVM monsterVM { get; set; }
		private int _currentHealth;

		public int Attack { get; set; }
		public int Move { get; set; }
		public int Range { get; set; }
		private bool _flying;
		public bool Flying {
			get
			{
				return _flying;
			}
			set
			{
				_flying = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flying"));
			}
		}
		public int Shield { get; set; }
		public string Special { get; set; }
		public int Number { get; set; }
		public ICommand togglePoisonedCommand{ get; private set;}
		public ICommand toggleWoundedCommand { get; private set; }
		public ICommand toggleCrippledCommand { get; private set; }
		public ICommand toggleStunnedCommand { get; private set; }
		public ICommand toggleConfusedCommand { get; private set; }
		public ICommand toggleDisarmedCommand { get; private set; }
		public ICommand toggleStrongCommand { get; private set; }
		public ICommand toggleInvisibleCommand { get; private set; }
		public ICommand SubtractHealthCommand { get; private set; }
		public ICommand AddHealthCommand { get; private set; }
		public ICommand DeleteCommand { get; private set; }

		private void SubtractHealthExecute()
		{
			System.Diagnostics.Debug.WriteLine("Trying to subtract health ");
			currentHealth--;
			if (currentHealth <= 0)
			{
				monsterVM.remove(this);

			}
		}
		//Returns currentHealth/MaxHealth, only get
		public string Health
		{
			get
			{
				return (_currentHealth + "/" + maxHealth);
			}
		}

		//Helper functions for status effect commands
		private void AddHealthExecute()
		{
			System.Diagnostics.Debug.WriteLine("Adding health");
			if (currentHealth < maxHealth)
			{
				currentHealth++;
			}
		}
		private void togglePoisonedExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Poisoned, " + poisoned);
			if (poisoned)
				poisoned = false;
			else
				poisoned = true;
		}
		private void toggleWoundedExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Wounded, " + wounded);
			if (wounded)
				wounded = false;
			else
				wounded = true;
		}
		private void toggleCrippledExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Crippled, " + crippled);
			if (crippled)
				crippled = false;
			else
				crippled = true;
		}
		private void toggleStunnedExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Stunned, " + stunned);
			if (stunned)
				stunned = false;
			else
				stunned = true;
		}
		private void toggleConfusedExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Confused, " + confused);
			if (confused) confused = false;
			else confused = true;
		}
		private void toggleDisarmedExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Disarmed, " + disarmed);
			if (disarmed)
				disarmed = false;
			else
				disarmed = true;
		}
		private void toggleStrongExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Strong, " + poisoned);
			strong = !strong;
		}
		private void toggleInvisibleExecute()
		{
			System.Diagnostics.Debug.WriteLine("toggling Invisible, " + poisoned);
			invisible = !invisible;
		}
		private void DeleteExecute()
		{
			System.Diagnostics.Debug.WriteLine("Deleting Monster, " + Name);
			monsterVM.remove(this);
		}
		public int currentHealth
		{
			get
			{
				return _currentHealth;
			}
			set
			{
				_currentHealth = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("currentHealth"));
					PropertyChanged(this, new PropertyChangedEventArgs("Health"));
				}
			}
		}
		public int maxHealth { get; set; }


		public Monster(int health, string name)
		{
			//Make Commands for the status effects
			SubtractHealthCommand = new Command(SubtractHealthExecute);
			AddHealthCommand = new Command(AddHealthExecute);
			togglePoisonedCommand = new Command(togglePoisonedExecute);
			toggleWoundedCommand = new Command(toggleWoundedExecute);
			toggleCrippledCommand = new Command(toggleCrippledExecute);
			toggleStunnedCommand = new Command(toggleStunnedExecute);
			toggleConfusedCommand = new Command(toggleConfusedExecute);
			toggleDisarmedCommand = new Command(toggleDisarmedExecute);
			toggleInvisibleCommand = new Command(toggleInvisibleExecute);
			toggleStrongCommand = new Command(toggleStrongExecute);
			DeleteCommand = new Command(DeleteExecute);

			currentHealth = health;
			maxHealth = health;
			Name = name;

			//Initialize all the status effects to false to start
			crippled = false;
			poisoned = false;
			confused = false;
			stunned = false;
			wounded = false;
			disarmed = false;
		}
		public Monster(int health, string name, int attack, int move, int range, bool flying, int shield, string special, int number)
		{
			//Make Commands for the status effects
			SubtractHealthCommand = new Command(SubtractHealthExecute);
			AddHealthCommand = new Command(AddHealthExecute);
			togglePoisonedCommand = new Command(togglePoisonedExecute);
			toggleWoundedCommand = new Command(toggleWoundedExecute);
			toggleCrippledCommand = new Command(toggleCrippledExecute);
			toggleStunnedCommand = new Command(toggleStunnedExecute);
			toggleConfusedCommand = new Command(toggleConfusedExecute);
			toggleDisarmedCommand = new Command(toggleDisarmedExecute);
			toggleInvisibleCommand = new Command(toggleInvisibleExecute);
			toggleStrongCommand = new Command(toggleStrongExecute);
			DeleteCommand = new Command(DeleteExecute);

			currentHealth = health;
			maxHealth = health;
			Name = name;
			Attack = attack;
			Move = move;
			Range = range;
			Flying = flying;
			Shield = shield;
			Special = special;
			Number = number;
			

			//Initialize all the status effects to false to start
			crippled = false;
			poisoned = false;
			confused = false;
			stunned = false;
			wounded = false;
			disarmed = false;
		}

	}


}
