using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Collections.ObjectModel;


namespace GloomHavenHealthTracker
{
    class Connection
    {
		private SQLiteConnection sql_con;
		private SQLiteCommand sql_cmd;
		private DataSet DS = new DataSet();
		private DataTable DT = new DataTable();
		private void SetConnection()
		{
			sql_con = new SQLiteConnection("Data Source=Assets/GloomHavenDB.db;Version=3;New=False;Compress=True;");
		}
/*		public List<Character> LoadCharacters()
		{
			List<Character> Characters = new List<Character>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = "Select Name, Experience, Gold, Class, HeroID from Hero where IsRetired is False";
			using (SQLiteDataReader rdr = sql_cmd.ExecuteReader())
			{
				while (rdr.Read())
				{
					string Name = rdr.GetString(0);
					int Experience = rdr.GetInt32(1);
					int Gold = rdr.GetInt32(2);
					string Class = rdr.GetString(3);
					int HeroID = rdr.GetInt32(4);
					Character newChar = new Character(Name, Gold, Experience, HeroID, Class);
					Characters.Add(newChar);
					System.Diagnostics.Debug.WriteLine("added something to characters");
				}
			}


			sql_con.Close();

			return Characters;
		}

		public ObservableCollection<Perk> LoadPerks(int HeroID)
		{
			ObservableCollection<Perk> returnValues = new ObservableCollection<Perk>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = "Select * from Perk where PerkHeroFK is '"+HeroID+"'" ;
			SQLiteDataReader r = sql_cmd.ExecuteReader();
			while (r.Read())
			{
				string effect = (string)r["Effect"];
				int taken = Convert.ToInt32(r["Taken"]);
				Perk perk = new Perk(effect, HeroID, taken);
				returnValues.Add(perk);
			}
			sql_con.Close();
			return returnValues;
		}

		public ObservableCollection<Item> LoadItems(int HeroID)
		{
			ObservableCollection<Item> returnValues = new ObservableCollection<Item>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = "Select * from Item where ItemHeroFK is '" + HeroID + "'";
			SQLiteDataReader r = sql_cmd.ExecuteReader();
			while (r.Read())
			{
				string name = (string)r["Name"];
				int cost = Convert.ToInt32(r["Cost"]);
				int id = Convert.ToInt32(r["ItemID"]);
				string effects = (string)r["Effects"];
				Item item = new Item(name, id,effects, cost);
				returnValues.Add(item);
			}
			sql_con.Close();
			return returnValues;
		}
		*/
		public List<string> LoadStr(string Command, string Field)
		{
			List<string> returnValues = new List<string>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = Command;
			SQLiteDataReader r = sql_cmd.ExecuteReader();
			while (r.Read())
			{
				string MonsterName = (string)r[Field];
				returnValues.Add(MonsterName);
			}
			sql_con.Close();
			return returnValues;
		}
		public List<int> LoadInt(string Command, string Field)
		{
			List<int> returnValues = new List<int>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = Command;
			SQLiteDataReader r = sql_cmd.ExecuteReader();
			while (r.Read())
			{
				int MonsterHealth = Convert.ToInt32(r[Field]);
				returnValues.Add(MonsterHealth);
			}
			sql_con.Close();
			return returnValues;
		}
		public List<bool> LoadBool(string Command, string Field)
		{
			List<bool> returnValues = new List<bool>();
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = Command;
			SQLiteDataReader r = sql_cmd.ExecuteReader();
			while (r.Read())
			{
				bool MonsterHealth = Convert.ToBoolean(r[Field]);
				returnValues.Add(MonsterHealth);
			}
			sql_con.Close();
			return returnValues;
		}
		public void ExecuteQuery(string Command)
		{
			SetConnection();
			sql_con.Open();
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText = Command;
			sql_cmd.ExecuteNonQuery();
			sql_con.Close();
		}
	}
}
