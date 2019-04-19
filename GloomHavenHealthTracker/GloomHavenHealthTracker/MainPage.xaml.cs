using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GloomHavenHealthTracker
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
			if (BindingContext is null)
			{
				BindingContext = this;
			}
			InitializeComponent();
			
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			//Add Monster Button, go to the add monster page
            var newAddPage = new Add_Monster();
            newAddPage.BindingContext = BindingContext;
            Navigation.PushAsync(newAddPage);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var newPage = new EditMonsterHealth();
            //newPage.BindingContext = (Monster)e.Item;
            System.Diagnostics.Debug.WriteLine("monster health " + ((Monster)e.Item).currentHealth);
			//Navigation.PushAsync(newPage);
			if (e == null)
				return; // has been set to null, do not 'process' tapped event 
			System.Diagnostics.Debug.WriteLine("Tapped: " + e.Item);
			((ListView)sender).SelectedItem = null; 
			// de-select the row 
		}
		private void RestoreMonster(object sender, EventArgs e)
		{
			((MonsterVM)BindingContext).restore();
		}
		private void addHealth(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("adding health");
			if (((Monster)BindingContext).currentHealth < ((Monster)BindingContext).maxHealth)
			{
				((Monster)BindingContext).currentHealth++;
				System.Diagnostics.Debug.WriteLine("added 1 health");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("already max health");
			}
		}
		private void minusHealth(object sender, ItemTappedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("subtracting health");
			if (((Monster)e.Item).currentHealth > 0)
			{
				((Monster)sender).currentHealth--;
				if (((Monster)sender).currentHealth == 0)
				{
					((Monster)sender).monsterVM.remove((Monster)BindingContext);
				}
			}
		}

		private void GoToCharSheets(object sender, EventArgs e)
		{
			var newPage = new CharacterList();
			Navigation.PushAsync(newPage);
		}
	}
}
