using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class MicrochipRobot
    {
        public int Id { get; private set; }
        public List<int> Microchips { get; private set; }

        public MicrochipRobotGiveCommand Command { get; private set; }

        public MicrochipRobot(int id)
        {
            Microchips = new List<int>();
            Id = id;
        }

        public void ReceiveMicrochip(int microchipId)
        {
            Microchips.Add(microchipId);
        }

        public bool IsReadyToGive() => Microchips.Count == 2;

        public void SetCommand(MicrochipRobotGiveCommand command)
        {
            if (Command != null)
            {
                throw new InvalidOperationException("Command is already set!");
            }

            Command = command;
        }
       
    }
}
