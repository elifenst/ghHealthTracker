using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GloomHavenHealthTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterDisplay : ContentPage
	{
		public CharacterDisplay ()
		{
			InitializeComponent ();
		}
		private void entrySet(object sender, EventArgs e)
		{
			((Character)BindingContext).Experience = Convert.ToInt32(ExperienceBox.Text);

		}

		private void AddItem_Pressed(object sender, EventArgs e)
		{
			var newPage = new AddItem();
			newPage.BindingContext = BindingContext;
			Navigation.PushAsync(newPage);
		}
		private void AddPerk_Pressed(object sender, EventArgs e)
		{
			var newPage = new AddPerk();
			newPage.BindingContext = BindingContext;
			Navigation.PushAsync(newPage);
		}
		private void Delete_Pressed(object sender, EventArgs e)
		{
			((Character)BindingContext).myCharacterVM.DeleteCharacter((Character)BindingContext);
			Navigation.PopAsync();
		}

		private void Perk1_Clicked(object sender, EventArgs e)
		{
			var asdf = (PerkWrapper)(((ImageButton)sender).BindingContext);
			if (asdf.Button1 == 1)
			{
				asdf.Taken -= 1;
			}
			else
			{
				asdf.Taken += 1;
			}
		}
		private void Perk2_Clicked(object sender, EventArgs e)
		{
			var asdf = (PerkWrapper)(((ImageButton)sender).BindingContext);
			if (asdf.Button2 == 1)
			{
				asdf.Taken -= 1;
			}
			else
			{
				asdf.Taken += 1;
			}
		}
	}
}