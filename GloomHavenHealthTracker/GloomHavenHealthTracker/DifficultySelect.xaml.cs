using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace GloomHavenHealthTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DifficultySelect : ContentPage
	{
		public DifficultySelect ()
		{
			var monsters = new ObservableCollection<Monster> { };
			InitializeComponent();
			BindingContext = new MonsterVM { Monsters = monsters };
		}
		private void Button_Clicked(object sender, EventArgs e)
		{
			if (LevelPicker.SelectedItem != null)
			{
				((MonsterVM)BindingContext).level = (string)LevelPicker.SelectedItem;
				//Add Monster Button, go to the add monster page
				var newAddPage = new MainPage();
				newAddPage.BindingContext = this.BindingContext;
				App.Current.MainPage = new NavigationPage(newAddPage);
			}
		}
	}
}