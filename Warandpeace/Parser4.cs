using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Characteristics;

namespace Warandpeace
{
    class Parser4
    {
        public string GetMostCommonWord()
        {
            var text = File.ReadAllText("warandpeace.txt");

            var stopSymbols = new char[] { ',', ' ', '.', ':', ';', '-', '\r', '\n' };

            var index = 0;
            var dictionary = new Dictionary<string, int>();
            var currentWord = "";
            while (index < text.Length)
            {
                if (stopSymbols.Contains(text[index]))
                {
                    if (currentWord == "")
                    {
                        index++;
                        continue;
                    }

                    var lowerCased = currentWord.ToLower();
                    if (dictionary.ContainsKey(lowerCased))
                    {
                        dictionary[lowerCased]++;
                    }
                    else
                    {
                        dictionary.Add(lowerCased, 1);
                    }

                    currentWord = "";
                }
                else
                {
                    currentWord += text[index];
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
            var currentWordChars = ArrayPool<char>.Shared.Rent(1000);
            var currentWordIndex = 0;
            var maxLength = 0;
            var longestWord = string.Empty;
            while (index < text.Length)
            {
                if (stopSymbols.Contains(text[index]))
                {
                    if (currentWordIndex == 0)
                    {
                        index++;
                        continue;
                    }

                    var currentWord = string.Concat(currentWordChars.Take(currentWordIndex));

                    if (dictionary.ContainsKey(currentWord))
                    {
                        dictionary[currentWord]++;
                    }
                    else
                    {
                        dictionary.Add(currentWord, 1);
                    }

                    if (dictionary[currentWord] > maxLength)
                    {
                        longestWord = currentWord;
                        maxLength = dictionary[currentWord];
                    }

                    currentWordIndex = 0;
                }
                else
                {
                    currentWordChars[currentWordIndex] = char.ToLower(text[index]);
                    currentWordIndex++;
                }

                index++;
            }

            return longestWord;
        }

        string MakeWord(char[] chars, int length)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(chars.AsSpan().Slice(0, length));
            return stringBuilder.ToString();
        }
    }
}