using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic
{
    public class KineticSculpture
    {

        private int _time;
        private int _currCapsulePosition;

        private readonly KineticSculptureDisc[] _discs;

        public KineticSculpture(KineticSculptureDisc[] discs = null)
        {
            if (discs != null)
            {
                _discs = discs;

            } else
            {
                _discs = new KineticSculptureDisc[]
                       {
                            new KineticSculptureDisc {InitialPosition = 2, NumOfPositions = 5},
                            new KineticSculptureDisc {InitialPosition = 7, NumOfPositions = 13},
                            new KineticSculptureDisc {InitialPosition = 10, NumOfPositions = 17},
                            new KineticSculptureDisc {InitialPosition = 2, NumOfPositions = 3},
                            new KineticSculptureDisc {InitialPosition = 9, NumOfPositions = 19},
                            new KineticSculptureDisc {InitialPosition = 0, NumOfPositions = 7},
                       };
            }
           
        }

        /// <summary>
        /// Executes a kinetic sculpture simulation
        /// </summary>
        /// <param name="timeToPressButton"></param>
        /// <returns>True is the capsule fall through, false otherwise</returns>
        public bool StartSimulation(int timeToPressButton)
        {
            _currCapsulePosition = 0;
            _time = timeToPressButton + 1;// One second to reach the first disc

            for (int i = 0; i < _discs.Length; i++)
            {
               int discPosition =  CalculateDiscPosition(_discs[i], _time);
               if (discPosition != 0)
                {
                    return false;
                }
                _time++;
            }
            //Passed all the discs
            return true;

        }

        private int CalculateDiscPosition(KineticSculptureDisc kineticSculptureDisc, int time)
        {
            int discPosition = (kineticSculptureDisc.InitialPosition + time) % kineticSculptureDisc.NumOfPositions;
            return discPosition;
        }
    }
}
