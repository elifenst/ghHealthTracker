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
	}
}