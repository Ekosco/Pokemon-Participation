using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for PokemonInfoWindow.xaml
    /// </summary>
    public partial class PokemonInfoWindow : Window
    {
        private PokemonDetailsAPI Info { get; set; }

        private bool ShouldIShowTheFront { get; set; }
        public PokemonInfoWindow()
        {
            InitializeComponent();
        }

        public void PopulateWindow(PokemonDetailsAPI info)
        {
            imgPokemon.Source = new BitmapImage(new Uri(info.sprites.front_default));
            lblHeight.Content = $"Height: {info.height}";
            lblWeight.Content = $"Weight: {info.weight}";
            lblTitle.Content = info.name;
            Info = info;
            ShouldIShowTheFront = false;
            //Uri is telling a program to go to a url, take the bits of that url, make a bitmapimage, and set it equal to the image source
            //info is passed into the window as the object 
            //made a class-level variable of info because we want to access it outside of just the PopulateWindow method 
        }

        private void SpriteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShouldIShowTheFront == true)
            {
                imgPokemon.Source = new BitmapImage(new Uri(Info.sprites.front_default));
                //ShouldIShowTheFront = false;
            }
            else
            {
                imgPokemon.Source = new BitmapImage(new Uri(Info.sprites.back_default));
                //ShouldIShowTheFront = true;
            }
            ShouldIShowTheFront = !ShouldIShowTheFront;
        }
    }
}
