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
	public partial class EditMonsterHealth : ContentPage
	{
        public BindableObject context { get; set; }
        
		public EditMonsterHealth ()
		{
			BindingContext = this;
			//context = BindingContext;
            //var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
			InitializeComponent ();
		}
        private void Button_Pressed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Pressed!");
            //Navigation.PushAsync(new Add_Monster());
            System.Diagnostics.Debug.WriteLine("health " + ((Monster)BindingContext).currentHealth);

        }
        private void addHealth(object sender, EventArgs e )
        {
            System.Diagnostics.Debug.WriteLine("adding health");
            if( ((Monster)BindingContext).currentHealth < ((Monster)BindingContext).maxHealth)
            {
                ((Monster)BindingContext).currentHealth++;
                System.Diagnostics.Debug.WriteLine("added 1 health");
            }
            else{
                System.Diagnostics.Debug.WriteLine("already max health");
            }
        }
        private void minusHealth(object sender, EventArgs e)
        {
			
            System.Diagnostics.Debug.WriteLine("subtracting health");
			if (((Monster)BindingContext).currentHealth > 0)
			{
				((Monster)BindingContext).currentHealth--;
				if(((Monster)BindingContext).currentHealth == 0)
				{
					((Monster)BindingContext).monsterVM.remove((Monster)BindingContext);
					Navigation.PopAsync();
				}
			}
        }
		private void DeleteMonster(object sender, EventArgs e)
		{
			((Monster)BindingContext).monsterVM.remove((Monster)BindingContext);
			Navigation.PopAsync();
		}
    }
}