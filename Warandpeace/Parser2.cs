using System.Collections.Generic;

namespace Warandpeace
{
    class Parser2
    {
        public string GetMostCommonWord(string text)
        {
            var words = text.Split(',', ' ', '.', ':', ';', '-', '\r', '\n');
            var dictionary = new Dictionary<string, int>();

            var mostCommonWord = "";
            var biggestLength = 0;
            foreach (var word in words)
            {
                if (word == string.Empty)
                {
                    continue;
                }

                var lowerCased = word.ToLower();
                if (dictionary.TryGetValue(lowerCased, out int currentLength))
                {
                    currentLength++;
                    dictionary[lowerCased] = currentLength;
                    if (currentLength > biggestLength)
                    {
                        mostCommonWord = word;
                        biggestLength = currentLength;
                    }
                }
                else
                {
                    dictionary.Add(lowerCased, 1);
                }
            }

            return mostCommonWord;
        }
    }
}