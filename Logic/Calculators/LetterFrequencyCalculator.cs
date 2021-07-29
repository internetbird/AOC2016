using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Calculators
{
    public class LetterFrequencyCalculator
    {

        public char GetMostFrequestCharAtPoisition(string[] words, int position)
        {
            var charDictionary = new Dictionary<char, int>();

            foreach(string word in words)
            {
                if (!charDictionary.ContainsKey(word[position]))
                {
                    charDictionary.Add(word[position], 1);
                } else
                {
                    charDictionary[word[position]]++;
                }
            }

            return charDictionary.OrderByDescending(keyVal => keyVal.Value).First().Key;
        }

        public char GetLeastFrequestCharAtPoisition(string[] words, int position)
        {
            var charDictionary = new Dictionary<char, int>();

            foreach (string word in words)
            {
                if (!charDictionary.ContainsKey(word[position]))
                {
                    charDictionary.Add(word[position], 1);
                }
                else
                {
                    charDictionary[word[position]]++;
                }
            }

            return charDictionary.OrderBy(keyVal => keyVal.Value).First().Key;
        }
    }
}
