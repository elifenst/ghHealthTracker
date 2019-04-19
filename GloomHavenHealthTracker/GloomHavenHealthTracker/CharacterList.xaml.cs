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
	public partial class CharacterList : ContentPage
	{
		public CharacterList ()
		{
			//Connection connection = new Connection();
			CharacterVM Characters = new CharacterVM();
			//Characters.CharacterList = connection.LoadCharacters();
			//System.Diagnostics.Debug.WriteLine("amount of characters: " + Characters.CharacterList.Count);
			BindingContext = Characters;
			InitializeComponent();
		}
		private void OpenCharacter(object thing, ItemTappedEventArgs e)
		{
			var newPage = new CharacterDisplay();
			//Character asdf = new Character((DbCharacter)e.Item);
			newPage.BindingContext = (Character)e.Item;
			Navigation.PushAsync(newPage);
		}

		private void AddCharacter(object sender, EventArgs e)
		{
			var newPage = new AddCharacter();
			newPage.BindingContext = this.BindingContext;
			Navigation.PushAsync(newPage);
		}
	}
}