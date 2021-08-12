using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic
{
    public class EasterBunnyComputer
    {
        private Dictionary<string, int> _registers;
        private List<EasterBunnyComputerInstruction> _program;
        private int _currentCommandIndex;

        public EasterBunnyComputer()
        {
            _registers = new Dictionary<string, int>
            {
                {"a", 0 },
                {"b", 0 },
                {"c", 0 },
                {"d", 0 }
            };

            _program = new List<EasterBunnyComputerInstruction>();
            _currentCommandIndex = 0;
        }

        public int GetRegisterValue(string registerName) => _registers[registerName];

        public void ExecuteProgram()
        {
            EasterBunnyComputerInstruction instructionToExecute = GetNextInstructionToExecute();

            while (instructionToExecute != null)
            {
                ExecuteInsturction(instructionToExecute);
                instructionToExecute = GetNextInstructionToExecute();
            }

        }

        private void ExecuteInsturction(EasterBunnyComputerInstruction instructionToExecute)
        {
            throw new NotImplementedException();
        }

        private EasterBunnyComputerInstruction GetNextInstructionToExecute()
        {
            if (_currentCommandIndex < _program.Count)
            {
                return _program[_currentCommandIndex];
            }

            return null;
        }

        public void LoadProgram(string[] instructionLines)
        {
            var insturctionBuilder = new EasterBunnyComputerInstructionBuilder();
            foreach (string line in instructionLines)
            {
                EasterBunnyComputerInstruction instruction = insturctionBuilder.BuildInstuction(line);
                _program.Add(instruction);
            }
        }
    }
}
