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
	public partial class AddPerk : ContentPage
	{
		public AddPerk ()
		{
			InitializeComponent ();
		}
		private void PerkId_Completed(object sender, EventArgs e)
		{
			Perk perk = new Perk();
			perk.Effect = Effect.Text;
			perk.Takable = Convert.ToInt32(Takable.Text);
			perk.Taken = 0;
			perk.PerkHeroFK = ((Character)BindingContext).HeroID;
			((Character)BindingContext).Perks.Add(new PerkWrapper(perk, ((Character)BindingContext).myCharacterVM));
			((Character)BindingContext).myCharacterVM.NewPerk(perk);
			Navigation.PopAsync();
		}
	}
}