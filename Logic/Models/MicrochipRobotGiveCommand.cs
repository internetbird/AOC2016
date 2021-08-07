using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class MicrochipRobotGiveCommand
    {
        public int RobotId { get; private set; }
        public int LowValueToId { get; private set; }
        public int HighValueToId { get; private set; }
        public MicrochipRobotGiveTo LowGiveTo { get; private set; }
        public MicrochipRobotGiveTo HighGiveTo { get; private set; }
        
        public MicrochipRobotGiveCommand(int robotId, int lowValueToId, MicrochipRobotGiveTo lowGiveTo,
                        int highValueTId, MicrochipRobotGiveTo highGiveTo)
        {
            RobotId = robotId;
            LowValueToId = lowValueToId;
            HighValueToId = highValueTId;
            LowGiveTo = lowGiveTo;
            HighGiveTo = highGiveTo;

        }
    }
}
