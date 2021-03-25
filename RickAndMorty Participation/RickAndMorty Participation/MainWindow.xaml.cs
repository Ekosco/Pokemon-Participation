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

namespace RickAndMorty_Participation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RickAndMortyAPI api;
            string url = "https://rickandmortyapi.com/api/character";
            /*while(string.IsNullOrEmpty(url) == false)
            {
                using (var client = new HttpClient())
                {
                    var json = client.GetStringAsync(url).Result;
                    api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);
                }

                foreach (Character item in api.results.OrderBy(x => x.name).ToList())
                {
                    characterLstBx.Items.Add(item);
                }

                url = api.info.next;*/
            //All you add is while loop and url statement for scrolling through all pages within max api display limit
            while (string.IsNullOrEmpty(url) == false)
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    //used to validate if there is an error or not: Response and if statement
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

                        foreach (Character item in api.results)
                        {
                            characterLstBx.Items.Add(item);
                        }

                        url = api.info.next;
                    }
                }
            }
        }

        private void characterLstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Character)characterLstBx.SelectedItem;
            characterImg.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }
    }
}
