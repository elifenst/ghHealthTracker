using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GloomHavenHealthTracker
{
	public class PerkWrapper : INotifyPropertyChanged
	{
		public Perk perk { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		public int Button1
		{
			get {
				return Taken >= 1 ? 1 : 0;
				}
		}
		public int Button2
		{
			get
			{
				return Taken >= 2 ? 1 : 0;
			}
		}
		public bool Button1Avail
		{
			get
			{
				return Takable >= 1;
			}
		}
		public bool Button2Avail
		{
			get
			{
				return Takable >= 2;
			}
		}
		private CharacterVM VM;
		public int Taken
		{
			get
			{
				return perk.Taken;
			}
			set
			{
				perk.Taken = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Perk1"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Perk2"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Button1"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Button2"));
				VM.SavePerk(this);

			}
		}
		public int Takable
		{
			get
			{
				return perk.Takable;
			}
			set
			{
				perk.Takable = value;
			}
		}
		public string Effect { get; set; }
		public PerkWrapper(Perk purk, CharacterVM vm)
		{
			VM = vm;
			perk = purk;
			Taken = purk.Taken;
			Takable = purk.Takable;
			Effect = purk.Effect;
		}

		
	}
}
