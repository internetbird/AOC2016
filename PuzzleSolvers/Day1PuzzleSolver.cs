using AOC2016.Logic;
using AOC2016.Logic.Builders;
using AOC2016.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day1PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var inputText = InputFilesHelper.GetInputFileText("day1.txt");

            var instructionBuilder = new WalkInstructionBuilder();
            List<WalkInstruction> instructions = instructionBuilder.Build(inputText);

            var robot = new CoordinatesRobot();
            foreach (WalkInstruction instruction in instructions)
            {
                robot.FollowInstruction(instruction);
            }

            return robot.GetTaxiCabDistance().ToString(); ;
        }

        public string SolvePuzzlePart2()
        {
            var inputText = InputFilesHelper.GetInputFileText("day1.txt");

            var instructionBuilder = new WalkInstructionBuilder();
            List<WalkInstruction> instructions = instructionBuilder.Build(inputText);

            var visitedCoordinates = new List<string> { "0,0" };
            var robot = new CoordinatesRobot();

            foreach (WalkInstruction instruction in instructions)
            {
                robot.Turn(instruction.SideToTurn);

                while(instruction.BlocksToWalk > 0)
                {
                    robot.Walk(1);
                    instruction.BlocksToWalk--;

                    var coordinateString = robot.GetCoordinateString();

                    if (!visitedCoordinates.Contains(coordinateString))
                    {
                        visitedCoordinates.Add(coordinateString);

                    }
                    else
                    {
                        return robot.GetTaxiCabDistance().ToString();
                    }
                }
            }

            return string.Empty;
        }
    }
}
