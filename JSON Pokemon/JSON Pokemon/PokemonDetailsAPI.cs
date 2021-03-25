using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class PokemonDetailsAPI
    {
        public double height { get; set; }
        public Sprites sprites { get; set; }
        public double weight { get; set; }
        public string name { get; set; }
    }

    public class Sprites
    {
        public string front_default { get; set; }
        public string back_default { get; set; }
    }
}
