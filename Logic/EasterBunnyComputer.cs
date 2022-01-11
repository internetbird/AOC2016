using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                    if (_registers.ContainsKey(instructionToExecute.Operand2))
                    {
                        _registers[instructionToExecute.Operand2] = valueToCopy;
                    }
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.Increase:
                    if (_registers.ContainsKey(instructionToExecute.Operand1))
                    {
                        _registers[instructionToExecute.Operand1]++;
                    }
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.Decrease:
                    if (_registers.ContainsKey(instructionToExecute.Operand1))
                    {
                        _registers[instructionToExecute.Operand1]--;
                    }
                    _currentCommandIndex++;
                    break;
                case EasterBunnyComputerInstructionType.JumpNotZero:
                    int value = GetOperandValue(instructionToExecute.Operand1);
                    if (value != 0)
                    {
                        int jumpValue = GetOperandValue(instructionToExecute.Operand2);
                        _currentCommandIndex += jumpValue;
                    }
                    else
                    {
                        _currentCommandIndex++;
                    }

                    break;
                case EasterBunnyComputerInstructionType.Toggle:
                    int instructionsAway = GetOperandValue(instructionToExecute.Operand1);
                    int instructionToToggleIndex = _currentCommandIndex + instructionsAway;
                    if (instructionToToggleIndex < _program.Count)
                    {
                       EasterBunnyComputerInstruction instructionToToggle =  _program[instructionToToggleIndex];
                       ToggleInstruction(instructionToToggle);
                    }

                    _currentCommandIndex++;

                    break;
                default:
                    break;
            }
        }

        private void PrintProgram()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("********PROGRAM*******");

            for (int i = 0; i < _program.Count ; i++)
            {
                if (i== _currentCommandIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{_program[i].Type} {_program[i].Operand1} {_program[i].Operand2 ?? string.Empty}");
            }
            Console.WriteLine("*********************");

            Console.WriteLine("------REGISTERS------");
            foreach (KeyValuePair<string, int> kvp in _registers)
            {
                Console.WriteLine($"[{kvp.Key}]  = {kvp.Value}");

            }
            Console.WriteLine("---------------------");
        }

        private void ToggleInstruction(EasterBunnyComputerInstruction instructionToToggle)
        {
            if (instructionToToggle.Operand2 == null) //One argument instruction
            {
                if (instructionToToggle.Type == EasterBunnyComputerInstructionType.Increase)
                {
                    instructionToToggle.Type = EasterBunnyComputerInstructionType.Decrease;
                } else
                {
                    instructionToToggle.Type = EasterBunnyComputerInstructionType.Increase;
                }
            }
            else  //Two arguments instruction
            {
                if (instructionToToggle.Type == EasterBunnyComputerInstructionType.JumpNotZero)
                {
                    instructionToToggle.Type = EasterBunnyComputerInstructionType.Copy;
                } else
                {
                    instructionToToggle.Type = EasterBunnyComputerInstructionType.JumpNotZero;
                }
            }

        }

        private int GetOperandValue(string operandStr)
        {
            if (_registers.ContainsKey(operandStr)) //Check if the operand is a register
            {
                return _registers[operandStr];
            }
            return int.Parse(operandStr);
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
