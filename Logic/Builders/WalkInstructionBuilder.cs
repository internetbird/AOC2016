using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Builders
{
    public class WalkInstructionBuilder
    {
        public List<WalkInstruction> Build(string inputText)
        {
            var instructions = new List<WalkInstruction>();

            string[] instructionStrings = inputText.Split(',');

            for (int i = 0; i < instructionStrings.Length; i++)
            {
                string currInstructionString = instructionStrings[i].Trim();
                var walkDirection = new WalkInstruction();

                walkDirection.SideToTurn = currInstructionString[0] == 'R' ? Side.Right : Side.Left;
                walkDirection.BlocksToWalk = int.Parse(currInstructionString.Substring(1));

                instructions.Add(walkDirection);
            }

            return instructions;
        }
    }
}
