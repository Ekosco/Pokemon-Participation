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

namespace ChuckNorrisAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://api.chucknorris.io/jokes/categories";
            string[] categories;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                categories = JsonConvert.DeserializeObject<string[]>(json);

                cbBx.Items.Add("All");
                cbBx.SelectedIndex = 0;
                //this adds the all option as the first in the combo box

                foreach(var result in categories)
                {
                    cbBx.Items.Add(result);
                }
            }
        }

        private void JokeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(cbBx.SelectedIndex == 0)
            {
                string url = "https://api.chucknorris.io/jokes/qP7S71sER2iFdk80zsISug";
                ChuckNorrisAPI api = new ChuckNorrisAPI();

                using(var client = new HttpClient())
                {
                    string json = client.GetStringAsync(url).Result;
                    api = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);
                    TxtBlck.Text = api.value;
                    ImgBx.Source = new BitmapImage(new Uri(api.icon_url));
                }
            }
            else
            {
                string url = $"https://api.chucknorris.io/jokes/random?category={cbBx.SelectedItem}";
                ChuckNorrisAPI api = new ChuckNorrisAPI();

                using(var client = new HttpClient())
                {
                    string json = client.GetStringAsync(url).Result;
                    api = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);
                    TxtBlck.Text = api.value;
                }
            }
        }
    }
}
