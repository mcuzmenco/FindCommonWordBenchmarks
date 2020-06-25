using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Characteristics;

namespace Warandpeace
{
    class Parser6
    {
        StringBuilder stringBuilder = new StringBuilder();

        public string GetMostCommonWord(string text)
        {
            var hz = text.AsSpan();
            var dictionary = new Dictionary<string, int>();
            var breakCharacters = new[] { ',', ' ', '.', ':', ';', '-', '\r', '\n' };
            var indexOfBreakChar = 0;
            while (hz.Length > 1 && indexOfBreakChar != -1)
            {
                indexOfBreakChar = hz.IndexOfAny(breakCharacters);
                if (indexOfBreakChar > 0)
                {
                    var currentWordChars = hz.Slice(0, indexOfBreakChar);

                    var currentWord = MakeWord(currentWordChars);

                    if (dictionary.ContainsKey(currentWord))
                    {
                        dictionary[currentWord]++;
                    }
                    else
                    {
                        dictionary.Add(currentWord, 1);
                    }

                    //if (dictionary[currentWord] > maxLength)
                    //{
                    //    longestWord = currentWord;
                    //    maxLength = dictionary[currentWord];
                    //}

                    hz = hz.Slice(indexOfBreakChar + 1);
                }
                else
                {
                    hz = hz.Slice(1);
                }
            }

            //return dictionary.OrderByDescending(x => x.Value).First().Key;
            return dictionary.First().Key;
        }



        public string GetMostCommonWord2(string text)
        {
            var hz = text.AsSpan();
            var dictionary = new Dictionary<string, int>();
            var indexOfBreakChar = 0;
            var stringBuilder = new StringBuilder();
            while (hz.Length > 1 && indexOfBreakChar != -1)
            {
                if (hz[0] == ' ')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == ',')
                {
                    hz = hz.Slice(1);
                    continue;
                }
                
                if (hz[0] == '.')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == ':')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == ';')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == ',')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == '-')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == '\r')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                if (hz[0] == '\n')
                {
                    hz = hz.Slice(1);
                    continue;
                }

                indexOfBreakChar = 0;
                stringBuilder.Clear();
                while (true)
                {
                    if (indexOfBreakChar == 0)
                    {
                        stringBuilder.Append(char.ToLowerInvariant(hz[indexOfBreakChar]));
                        indexOfBreakChar++;
                        continue;
                    }

                    if (hz[indexOfBreakChar] == ' ')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == ',')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == '.')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == ':')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == ';')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == ',')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == '-')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == '\r')
                    {
                        break;
                    }

                    if (hz[indexOfBreakChar] == '\n')
                    {
                        break;
                    }

                    stringBuilder.Append(char.ToLowerInvariant(hz[indexOfBreakChar]));
                    indexOfBreakChar++;
                }

                var currentWord = stringBuilder.ToString();
                if (dictionary.ContainsKey(currentWord))
                {
                    dictionary[currentWord]++;
                }
                else
                {
                    dictionary.Add(currentWord, 1);
                }

                hz = hz.Slice(indexOfBreakChar + 1);
            }

            return dictionary.OrderByDescending(x => x.Value).First().Key;
        }



        string MakeWord(ReadOnlySpan<char> wordChars)
        {
            stringBuilder.Clear();
            stringBuilder.Append(wordChars);
            return stringBuilder.ToString();
        }
    }
}