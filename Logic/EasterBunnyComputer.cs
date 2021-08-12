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

        public EasterBunnyComputer(Dictionary<string, int> initialRegisters = null)
        {
            _registers = initialRegisters;

            if (_registers == null) //Set the default value
            {
                _registers = new Dictionary<string, int>
                        {
                            {"a", 0 },
                            {"b", 0 },
                            {"c", 0 },
                            {"d", 0 }
                        };

            }

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
            switch (instructionToExecute.Type)
            {
                case EasterBunnyComputerInstructionType.Copy:
                    int valueToCopy = GetOperandValue(instructionToExecute.Operand1);
                    _registers[instructionToExecute.Operand2] = valueToCopy;
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.Increase:
                    _registers[instructionToExecute.Operand1]++;
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.Decrease:
                    _registers[instructionToExecute.Operand1]--;
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.JumpNotZero:
                    int value = GetOperandValue(instructionToExecute.Operand1);
                    if (value != 0)
                    {
                        _currentCommandIndex += int.Parse(instructionToExecute.Operand2);
                    }
                    else
                    {
                        _currentCommandIndex++;
                    }

                    break;
                default:
                    break;
            }
        }

        private int GetOperandValue(string operand1)
        {
            if (_registers.ContainsKey(operand1)) //Check if the operand is a register
            {
                return _registers[operand1];
            }
            return int.Parse(operand1);
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
