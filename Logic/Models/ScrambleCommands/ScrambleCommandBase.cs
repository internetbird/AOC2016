using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    public abstract class ScrambleCommandBase : IScrambleCommand
    {
        protected object[] _parameters;

        public ScrambleCommandBase(object[] parameters)
        {
            _parameters = parameters;
        }

        public abstract string Execute(string input);
    }
}
