using dotMorten.Xamarin.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GloomHavenHealthTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Add_Monster : ContentPage
	{
        public BindableObject context { get; set; }
		public Add_Monster ()
		{
            if (BindingContext is null)
            {
                BindingContext = this;
            }
			InitializeComponent ();
			
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			StartBox.Focus();
		}

		private void entrySet(object sender, EventArgs e)
        {
			NameBox.Focus();			
            
        }
		private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
		{
			// Only get results when it was a user typing, 
			// otherwise assume the value got filled in by TextMemberPath 
			// or the handler for SuggestionChosen.
			if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
			{
				string Search = sender.Text;
				Connection con = new Connection();
				string query = "Select distinct Name from Monster where Name like '%" + Search + "%'";
				List<string> dataset = con.LoadStr(query, "Name");
				//Set the ItemsSource to be your filtered dataset
				sender.ItemsSource = dataset;
			}
		}


		private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
		{
			// Set sender.Text. You can use args.SelectedItem to build your text string.
			sender.Text = args.SelectedItem.ToString();
		}


		private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
		{
			string MonsterName;
			if (args.ChosenSuggestion != null)
			{
				// User selected an item from the suggestion list, take an action on it here.
				MonsterName = args.ChosenSuggestion.ToString();
			}
			else
			{
				// User hit Enter from the search box. Use args.QueryText to determine what to do.
				MonsterName = args.QueryText;
			}
			Connection con = new Connection();
			string level = ((MonsterVM)BindingContext).level;
			try
			{
				string query = "select Health from Monster where Name is '" + MonsterName + "' and Level is " + level;
				List<int> dataset = con.LoadInt(query, "Health");
				int health = dataset[0];
				dataset.Clear();
				query = "select Attack from Monster where Name is '" + MonsterName + "' and Level is " + level;
				dataset = con.LoadInt(query, "Attack");
				int attack = dataset[0];
				dataset.Clear();
				query = "select Move from Monster where Name is '" + MonsterName + "' and Level is " + level;
				dataset = con.LoadInt(query, "Move");
				int move = dataset[0];
				dataset.Clear();
				query = "select Range from Monster where Name is '" + MonsterName + "' and Level is " + level;
				dataset = con.LoadInt(query, "Range");
				int range = dataset[0];
				dataset.Clear();
				query = "select Shield from Monster where Name is '" + MonsterName + "' and Level is " + level;
				dataset = con.LoadInt(query, "Shield");
				int shield = dataset[0];
				dataset.Clear();
				query = "select Notes from Monster where Name is '" + MonsterName + "' and Level is " + level;
				List<string> dataset2 = con.LoadStr(query, "Notes");
				string Notes = dataset2[0];
				query = "select Flying from Monster where Name is '" + MonsterName + "' and Level is " + level;
				List<bool> dataset3 = con.LoadBool(query, "Flying");
				bool flying = dataset3[0];
				int Number = 0;
				try
				{
					Number = Int32.Parse(StartBox.Text);

				}
				catch (FormatException)
				{
					System.Diagnostics.Debug.WriteLine("unable to parse for number");
				}
				catch (ArgumentNullException)
				{

				}

				Monster monster = new Monster(health, MonsterName, attack, move, range, flying, shield, Notes, Number);
				((MonsterVM)BindingContext).add(monster);
			}
			catch
			{

			}

			Navigation.PopAsync();
		}
	}

}