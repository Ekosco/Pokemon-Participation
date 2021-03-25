using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AllPokemonAPI api;
            string url = "https://pokeapi.co/api/v2/pokemon?limit=1200";
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);
            }

            foreach(ResultObject item in api.results.OrderBy(x => x.name).ToList())
            {
                LstBox.Items.Add(item);
            }
            //ResultObject refers to the method we created in the AllPokemonAPI class
        }

        private void LstBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResultObject selectedPokemon = (ResultObject)LstBox.SelectedItem;
            //Give me the item they selected from the LstBox
            //What is it we put in our listbox? We don't look at seperate class, we need to cast it to what we put in listbox
            //Change the variable within the foreach loop to ResultObject to run through the results like we want them to, making it easier
            //to cast to the double mouse click
            //If we add other things to it, we need to make sure its a resultobject 
            PokemonDetailsAPI info;

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(selectedPokemon.url).Result;
                //GetStringAsync: go to this url and read the contents in as a string

                info = JsonConvert.DeserializeObject<PokemonDetailsAPI>(json);
                //Deserialization object is taking all of info in API and converting it to an instance of the PokemonDetailsAPI class

            }

            PokemonInfoWindow wnd = new PokemonInfoWindow();
            wnd.PopulateWindow(info);
            //this method only allows the user to have one window open
            wnd.ShowDialog();

        }
    }
}
