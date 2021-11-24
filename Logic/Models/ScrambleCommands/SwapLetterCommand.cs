using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /*swap letter x with letter y*/
    public class SwapLetterCommand : ScrambleCommandBase
    {
        public SwapLetterCommand(object[] parameters) : base(parameters)
        {
        }

        public override string Execute(string input) => SwapLetters(input);
        public override string Undo(string input) => SwapLetters(input);
    
        private string SwapLetters(string input)
        {
            char firstLetter = (char)_parameters[0];
            char secondLetter = (char)_parameters[1];

            int firstLetterIndex = input.IndexOf(firstLetter);
            int secondLetterIndex = input.IndexOf(secondLetter);

            string result = input.SwapIndexes(firstLetterIndex, secondLetterIndex);
            return result;
        }
    }
}
