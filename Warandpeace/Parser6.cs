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
        public string GetMostCommonWord2(string text)
        {
            var textAsSpan = text.ToLowerInvariant().AsSpan();
            var dictionary = new Dictionary<string, int>(50000);
            var indexOfBreakChar = 0;
            var stringBuilder = new StringBuilder();
            var currentBiggestLength = 0;
            var mostCommonWord = string.Empty;
            while (textAsSpan.Length > 1 && indexOfBreakChar != -1)
            {
                if (textAsSpan[0] == ' ')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == ',')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }
                
                if (textAsSpan[0] == '.')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == ':')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == ';')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == ',')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == '-')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == '\r')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                if (textAsSpan[0] == '\n')
                {
                    textAsSpan = textAsSpan.Slice(1);
                    continue;
                }

                indexOfBreakChar = 0;
                stringBuilder.Clear();
                while (true)
                {
                    if (indexOfBreakChar == 0)
                    {
                        stringBuilder.Append(textAsSpan[indexOfBreakChar]);
                        indexOfBreakChar++;
                        continue;
                    }

                    if (textAsSpan[indexOfBreakChar] == ' ')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == ',')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == '.')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == ':')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == ';')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == ',')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == '-')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == '\r')
                    {
                        break;
                    }

                    if (textAsSpan[indexOfBreakChar] == '\n')
                    {
                        break;
                    }

                    stringBuilder.Append(textAsSpan[indexOfBreakChar]);
                    indexOfBreakChar++;
                }

                var currentWord = stringBuilder.ToString();
                if (dictionary.TryGetValue(currentWord, out int length))
                {
                    length++;
                    if (length > currentBiggestLength)
                    {
                        currentBiggestLength = length;
                        mostCommonWord = currentWord;
                    }

                    dictionary[currentWord] = length;
                }
                else
                {
                    dictionary.Add(currentWord, 1);
                }

                textAsSpan = textAsSpan.Slice(indexOfBreakChar + 1);
            }

            return mostCommonWord;
        }
    }
}