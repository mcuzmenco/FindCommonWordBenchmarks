using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Warandpeace
{
    class Parser1
    {
        public string GetMostCommonWord()
        {
            var text = File.ReadAllText("warandpeace.txt");
            var words = text.Split(',', ' ', '.', ':', ';', '-', '\r', '\n');
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (word == "")
                {
                    continue;
                }

                var lowerCased = word.ToLower();
                if (dictionary.ContainsKey(lowerCased))
                {
                    dictionary[lowerCased]++;
                }
                else
                {
                    dictionary.Add(lowerCased, 1);
                }
            }

            return dictionary.OrderByDescending(x => x.Value).First().Key;
        }

        public string GetMostCommonWord(string text)
        {
            var words = text.Split(',', ' ', '.', ':', ';', '-', '\r', '\n');
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (word == "")
                {
                    continue;
                }

                var lowerCased = word.ToLower();
                if (dictionary.ContainsKey(lowerCased))
                {
                    dictionary[lowerCased]++;
                }
                else
                {
                    dictionary.Add(lowerCased, 1);
                }
            }

            return dictionary.OrderByDescending(x => x.Value).First().Key;
        }
    }
}