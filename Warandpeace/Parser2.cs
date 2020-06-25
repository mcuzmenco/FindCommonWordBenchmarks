using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Warandpeace
{
    class Parser2
    {
        public string GetMostCommonWord()
        {
            var text = File.ReadAllText("warandpeace.txt");
            var words = text.Split(',', ' ', '.', ':', ';', '-', '\r', '\n');
            var dictionary = new Dictionary<string, int>();

            var mostCommonWord = "";
            var biggestLength = 0;
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
                    if (dictionary[lowerCased] > biggestLength)
                    {
                        mostCommonWord = word;
                        biggestLength = dictionary[lowerCased];
                    }
                }
                else
                {
                    dictionary.Add(lowerCased, 1);
                }
            }

            return mostCommonWord;
        }

        public string GetMostCommonWord(string allText)
        {
            var words = allText.Split(',', ' ', '.', ':', ';', '-', '\r', '\n');
            var dictionary = new Dictionary<string, int>();

            //var mostCommonWord = "";
            var biggestLength = 0;
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
                    if (dictionary[lowerCased] > biggestLength)
                    {
                        //mostCommonWord = word;
                        biggestLength = dictionary[lowerCased];
                    }
                }
                else
                {
                    dictionary.Add(lowerCased, 1);
                }
            }

            return dictionary.First(x => x.Value == biggestLength).Key;
        }
    }
}