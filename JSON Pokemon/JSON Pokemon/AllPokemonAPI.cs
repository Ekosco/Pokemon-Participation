using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_Pokemon
{
    public class AllPokemonAPI
    { 
        public List<ResultObject> results { get; set; }
    }

    public class ResultObject
    {
        public string name { get; set; }
        public string url { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
