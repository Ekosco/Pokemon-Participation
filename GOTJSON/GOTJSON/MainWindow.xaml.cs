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

namespace GOTJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url = "https://got-quotes.herokuapp.com/quotes";
                QuoteAPI quote = new QuoteAPI();
                QuoteAPI Character = new QuoteAPI();

                string json = client.GetStringAsync(url).Result;
                QuoteAPI api = JsonConvert.DeserializeObject<QuoteAPI>(json);

                QtBx.Text = quote.quote;
                CharacterBx.Text = quote.character;

            }
        }
    }
}
