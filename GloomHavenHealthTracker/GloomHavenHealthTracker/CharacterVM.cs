using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace GloomHavenHealthTracker
{
    public class CharacterVM
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ObservableCollection<Hero> HeroList { get; set; }
		private ObservableCollection<Character> _characterList;
		public ObservableCollection<Character> CharacterList
		{
			get
			{
				return _characterList;
			}
			set
			{
				_characterList = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharacterList"));
			}

		}
		private static object collisionLock = new object();
		private SQLiteConnection database;

		public CharacterVM()
		{
			database = DependencyService.Get<IDatabaseConnection>().DBConnection();
			database.CreateTable<Hero>();
			database.CreateTable<Item>();
			database.CreateTable<Perk>();

			HeroList = new ObservableCollection<Hero>(database.Table<Hero>());
			CharacterList = new ObservableCollection<Character>();
			//retrieve the hero's items and such, then put it into characterlist
			foreach (Hero hero in HeroList)
			{
				IEnumerable<Item> items = GetFilteredItems(hero.HeroID);
				IEnumerable<Perk> perks = GetFilteredPerks(hero.HeroID);
				List < PerkWrapper > PerkWs = new List<PerkWrapper>();
				foreach(Perk perk in perks)
				{
					PerkWs.Add(new PerkWrapper(perk, this));
				}
				Character character = new Character(hero, items.ToList(), PerkWs, this);
				CharacterList.Add(character);
			}
		}

		public int NewItem(Item item)
		{
			lock (collisionLock)
			{
				//Update hero
				database.Insert(item);
				return item.ItemPK;
			}
		}

		public int NewPerk(Perk perk)
		{
			lock (collisionLock)
			{
				//Update hero
				database.Insert(perk);
				return perk.PerkPK;
			}
		}

		public IEnumerable<Item> GetFilteredItems(int HeroID)
		{
			lock (collisionLock)
			{
				var query = from item in database.Table<Item>()
							where item.ItemHeroFK == HeroID
							select item;
				return query.AsEnumerable();
			}
		}

		public IEnumerable<Perk> GetFilteredPerks(int HeroID)
		{
			lock (collisionLock)
			{
				var query = from perk in database.Table<Perk>()
							where perk.PerkHeroFK == HeroID
							select perk;
				return query.AsEnumerable();
			}
		}
		public void DeleteItem(Item item)
		{
			lock (collisionLock)
			{
				database.Delete(item);
			}
		}
		public void DeletePerk(Perk perk)
		{
			lock (collisionLock)
			{
				database.Delete(perk);
			}
		}
		public void DeleteCharacter(Character character)
		{
			foreach(var item in character.Items)
			{
				DeleteItem(item);
			}
			foreach(var perk in character.Perks)
			{
				DeletePerk(perk.perk);
			}
			HeroList.Remove(character.hero);
			CharacterList.Remove(character);
			database.Delete(character.hero);

		}
		public void AddNewCharacter(Character character)
		{
			HeroList.Add(character.hero);
			CharacterList.Add(character);
			SaveAllCharacters();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharacterList"));
		}
		public IEnumerable<Hero> GetFilteredCharacters(string name)
		{
			lock (collisionLock)
			{
				var query = from chara in database.Table<Hero>()
							where chara.Name == name
							select chara;
				return query.AsEnumerable();
			}
		}
		public IEnumerable<Hero> GetFilteredCharacters()
		{
			lock (collisionLock)
			{
				var query = from chara in database.Table<Hero>()
							select chara;
				return query.AsEnumerable();
			}
		}
		public Hero GetDbCharacter(int id)
		{
			lock (collisionLock)
			{
				return database.Table<Hero>().FirstOrDefault(character => character.HeroID == id);
			}
		}
		public int SaveCharacter(Character characterInstance)
		{
			lock (collisionLock)
			{
				//Update hero
				database.Update(characterInstance.hero);
				//update items
				foreach (var item in characterInstance.Items)
				{
					database.Update(item);
				}
				//update perks
				foreach (var perk in characterInstance.Perks)
				{
					database.Update(perk.perk);
				}

				return characterInstance.HeroID;
			}
		}
		public void SaveAllCharacters()
		{
			lock (collisionLock)
			{
				foreach (var characterInstance in CharacterList)
				{
					//Update hero
					database.Update(characterInstance.hero);
					//update items
					foreach(var item in characterInstance.Items)
					{
						database.Update(item);
					}
					//update perks
					foreach (var perk in characterInstance.Perks)
					{
						database.Update(perk);
					}
				}
			}
		}
		public int NewHero(Hero hero)
		{
			lock (collisionLock)
			{
				//Update hero
				database.Insert(hero);
				Character newChar = new Character(hero, new List<Item>(), new List<PerkWrapper>(), this);
				this.CharacterList.Add(newChar);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CharacterList"));
				return hero.HeroID;
			}
		}
		public void SavePerk(PerkWrapper perk)
		{
			lock (collisionLock)
			{
					database.Update(perk.perk);

			}
		}
	}
}
