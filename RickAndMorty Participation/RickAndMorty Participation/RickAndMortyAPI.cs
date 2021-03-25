using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty_Participation
{
    public class RickAndMortyAPI
    {
        public Info info { get; set; }
        public List<Character> results;
    }

    public class Character
    {
        public string name { get; set; }
        public string image { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }
    }

    public class Info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
    }
}
