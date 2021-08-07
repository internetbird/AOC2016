using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Builders
{
    public class MicrochipRobotCommandsBuilder
    {
        public List<MicrochipRobotBasicCommand> BuildBasicCommands(string[] inputLines)
        {
            var commands = new List<MicrochipRobotBasicCommand>();

            foreach (string inputLine in inputLines)
            {
                if (inputLine.StartsWith("value"))
                {
                    string[] lineParts = inputLine.Split(' ');
                    var command = new MicrochipRobotBasicCommand();
                    command.RobotId = int.Parse(lineParts[5]);
                    command.Value = int.Parse(lineParts[1]);
                    commands.Add(command);
                }
            }
            return commands;
        }

        public List<MicrochipRobotGiveCommand> BuildGiveCommands(string[] inputLines)
        {
            var commands = new List<MicrochipRobotGiveCommand>();
            foreach (string inputLine in inputLines)
            {
                if (inputLine.StartsWith("bot"))
                {
                    string[] lineParts = inputLine.Split(' ');

                    int robotId = int.Parse(lineParts[1]);
                    MicrochipRobotGiveTo lowValueGiveTo = lineParts[5] == "bot" ? MicrochipRobotGiveTo.Bot : MicrochipRobotGiveTo.Output;
                    int lowValueToId = int.Parse(lineParts[6]);

                    MicrochipRobotGiveTo highValueGiveTo = lineParts[10] == "bot" ? MicrochipRobotGiveTo.Bot : MicrochipRobotGiveTo.Output;
                    int  highValueToId = int.Parse(lineParts[11]);

                    var command = new MicrochipRobotGiveCommand(robotId, lowValueToId, lowValueGiveTo, highValueToId, highValueGiveTo);
                    commands.Add(command);
                }
            }

            return commands;
        }
    }
}
