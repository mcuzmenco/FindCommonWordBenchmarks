using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Warandpeace
{
    class Parser3
    {
        public string GetMostCommonWord()
        {
            var text = File.ReadAllText("warandpeace.txt");

            var stopSymbols = new char[] {',', ' ', '.', ':', ';', '-', '\r', '\n'};

            var index = 0;
            var dictionary = new Dictionary<string, int>();
            var stringBuilder = new StringBuilder();
            while (index < text.Length)
            {
                if (stopSymbols.Contains(text[index]))
                {
                    if (stringBuilder.Length == 0)
                    {
                        index++;
                        continue;
                    }

                    var lowerCased = stringBuilder.ToString();
                    if (dictionary.ContainsKey(lowerCased))
                    {
                        dictionary[lowerCased]++;
                    }
                    else
                    {
                        dictionary.Add(lowerCased, 1);
                    }

                    stringBuilder.Clear();
                }
                else
                {
                    stringBuilder.Append(char.ToLower(text[index]));
                }

                index++;
            }

            return dictionary.OrderByDescending(x => x.Value).First().Key;
        }

        public string GetMostCommonWord(string text)
        {
            var stopSymbols = new HashSet<char>()
            {
                ',', ' ', '.', ':', ';', '-', '\r', '\n'
            };

            var index = 0;
            var dictionary = new Dictionary<string, int>();
            var stringBuilder = new StringBuilder();
            while (index < text.Length)
            {
                if (stopSymbols.Contains(text[index]))
                {
                    if (stringBuilder.Length == 0)
                    {
                        index++;
                        continue;
                    }

                    var lowerCased = stringBuilder.ToString();
                    if (dictionary.ContainsKey(lowerCased))
                    {
                        dictionary[lowerCased]++;
                    }
                    else
                    {
                        dictionary.Add(lowerCased, 1);
                    }

                    stringBuilder.Clear();
                }
                else
                {
                    stringBuilder.Append(char.ToLower(text[index]));
                }

                index++;
            }

            return dictionary.OrderByDescending(x => x.Value).First().Key;
        }
    }
}