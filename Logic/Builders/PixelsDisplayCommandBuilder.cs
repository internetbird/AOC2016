using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Builders
{
    public class PixelsDisplayCommandBuilder
    {

        public PixelsDisplayCommand Build(string commandText)
        {
            var command = new PixelsDisplayCommand();
            commandText = commandText.Trim();

            if (commandText.StartsWith("rect"))
            {
                command.Type = PixelsDisplayCommandType.Rectangle;

                string[] commandParts = commandText.Split(' ');

                command.CommandValue1 = int.Parse(commandParts[1].Split("x")[0]);
                command.CommandValue2 = int.Parse(commandParts[1].Split("x")[1]);

            } else if (commandText.StartsWith("rotate row"))
            {
                command.Type = PixelsDisplayCommandType.RotateRow;

                string[] valuesParts = commandText.Substring(11).Split(' ');
                command.CommandValue1 = int.Parse(valuesParts[0].Split('=')[1]);
                command.CommandValue2 = int.Parse(valuesParts[2]);


            } else //rotate column
            {
                command.Type = PixelsDisplayCommandType.RotateColumn;

                string[] valuesParts = commandText.Substring(14).Split(' ');
                command.CommandValue1 = int.Parse(valuesParts[0].Split('=')[1]);
                command.CommandValue2 = int.Parse(valuesParts[2]);
            }

            return command;
        }
    }
}
