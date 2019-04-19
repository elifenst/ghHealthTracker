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
	public partial class AddCharacter : ContentPage
	{
		public AddCharacter ()
		{
			InitializeComponent ();
		}

		private void Experience_Completed(object sender, EventArgs e)
		{
			Hero hero = new Hero();
			hero.Name = Name.Text;
			hero.Class = Class.Text;
			hero.Experience = Convert.ToInt32(Experience.Text);
			hero.Gold = Convert.ToInt32(Gold.Text);
			((CharacterVM)BindingContext).NewHero(hero);
			Navigation.PopAsync();
		}
	}
}