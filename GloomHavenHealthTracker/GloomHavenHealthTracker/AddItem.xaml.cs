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
	public partial class AddItem : ContentPage
	{
		public AddItem ()
		{
			InitializeComponent ();
		}
		private void ItemID_Completed(object sender, EventArgs e)
		{
			Item item = new Item();
			item.Name = Name.Text;
			item.Effects = Effects.Text;
			item.Cost = Convert.ToInt32(Cost.Text);
			item.ID = Convert.ToInt32(ItemID.Text);
			item.ItemHeroFK = ((Character)BindingContext).HeroID;
			((Character)BindingContext).Items.Add(item);
			((Character)BindingContext).myCharacterVM.NewItem(item);
			Navigation.PopAsync();
		}
	}

}