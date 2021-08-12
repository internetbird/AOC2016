using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Builders
{
    public class EasterBunnyComputerInstructionBuilder
    {
        public EasterBunnyComputerInstruction BuildInstuction(string instructionText)
        {
            var instruction = new EasterBunnyComputerInstruction();
            string[] instructionParts = instructionText.Split();

            EasterBunnyComputerInstructionType type = EasterBunnyComputerInstructionType.NotSet;

            switch (instructionParts[0])
            {
                case "cpy":
                    type = EasterBunnyComputerInstructionType.Copy;
                    break;
                case "inc":
                    type = EasterBunnyComputerInstructionType.Increase;
                    break;
                case "dec":
                    type = EasterBunnyComputerInstructionType.Decrease;
                    break;
                case "jnz":
                    type = EasterBunnyComputerInstructionType.JumpNotZero;
                    break;
            }
            string operand1 = instructionParts[1];
            string operand2 = null;
            if (instructionParts.Length > 2)
            {
                operand2 = instructionParts[2];
            }

            instruction.Type = type;
            instruction.Operand1 = operand1;
            instruction.Operand2 = operand2;

            return instruction;
        }
    }
}
