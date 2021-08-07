using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day10PuzzleSolver : IPuzzleSolver
    {

        private List<MicrochipRobot> _robotsCommunity;
        private int[] _outputs;

        public Day10PuzzleSolver()
        {
            _robotsCommunity = new List<MicrochipRobot>();
            _outputs = new int[3];
        }

        public string SolvePuzzlePart1()
        {
            string[] commandLines = InputFilesHelper.GetInputFileLines("day10.txt");


            var commandBuilder = new MicrochipRobotCommandsBuilder();
            List<MicrochipRobotBasicCommand> basicCommands = commandBuilder.BuildBasicCommands(commandLines);
            List<MicrochipRobotGiveCommand> giveCommands = commandBuilder.BuildGiveCommands(commandLines);

            foreach (MicrochipRobotGiveCommand giveCommand in giveCommands)
            {
                MicrochipRobot currRobot = _robotsCommunity.FirstOrDefault(robot => robot.Id == giveCommand.RobotId);

                if (currRobot == null)
                {
                    currRobot = new MicrochipRobot(giveCommand.RobotId);
                    _robotsCommunity.Add(currRobot);
                }

                currRobot.SetCommand(giveCommand);
            }

            foreach (MicrochipRobotBasicCommand basicCommand in basicCommands)
            {
                MicrochipRobot currRobot = _robotsCommunity.FirstOrDefault(robot => robot.Id == basicCommand.RobotId);

                if (currRobot == null)
                {
                    currRobot = new MicrochipRobot(basicCommand.RobotId);
                    _robotsCommunity.Add(currRobot);
                }

                DoMicrochipReceiveActions(currRobot, basicCommand.Value);
            }

            return string.Empty;
        }

        private void DoMicrochipReceiveActions(MicrochipRobot robot, int microchip)
        {
            robot.ReceiveMicrochip(microchip);

            if (robot.IsReadyToGive())
            {
                if (robot.Microchips.Min() == 17 && robot.Microchips.Max() == 61)
                {
                    Console.WriteLine($"Found the right robot with Id = {robot.Id}!");
                }

                //Execute the give command
                MicrochipRobotGiveCommand giveCommand = robot.Command;

                if (giveCommand.LowGiveTo == MicrochipRobotGiveTo.Bot)
                {
                    int lowValue = robot.Microchips.Min();
                    MicrochipRobot robotToGive = _robotsCommunity.First(robot => giveCommand.LowValueToId == robot.Id);
                    DoMicrochipReceiveActions(robotToGive, lowValue);
                } else //Output
                {
                    if (giveCommand.LowValueToId >= 0 && giveCommand.LowValueToId <= 2)
                    {
                        _outputs[giveCommand.LowValueToId] = robot.Microchips.Min();
                    }
                }

                if (giveCommand.HighGiveTo == MicrochipRobotGiveTo.Bot)
                {
                    int highValue = robot.Microchips.Max();
                    MicrochipRobot robotToGive = _robotsCommunity.First(robot => giveCommand.HighValueToId == robot.Id);
                    DoMicrochipReceiveActions(robotToGive, highValue);
                } else //Output
                {
                    if (giveCommand.HighValueToId >= 0 && giveCommand.HighValueToId <= 2)
                    {
                        _outputs[giveCommand.HighValueToId] = robot.Microchips.Max();
                    }
                }
            }
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
