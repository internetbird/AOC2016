using AOC2016.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day15PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int timeToPressButton = 0;

            var kineticSculpture = new KineticSculpture();

            while(!kineticSculpture.StartSimulation(timeToPressButton))
            {
                timeToPressButton++;
            }

            return timeToPressButton.ToString();
        }

        public string SolvePuzzlePart2()
        {
            int timeToPressButton = 0;

            var discs = new KineticSculptureDisc[]
                       {
                            new KineticSculptureDisc {InitialPosition = 2, NumOfPositions = 5},
                            new KineticSculptureDisc {InitialPosition = 7, NumOfPositions = 13},
                            new KineticSculptureDisc {InitialPosition = 10, NumOfPositions = 17},
                            new KineticSculptureDisc {InitialPosition = 2, NumOfPositions = 3},
                            new KineticSculptureDisc {InitialPosition = 9, NumOfPositions = 19},
                            new KineticSculptureDisc {InitialPosition = 0, NumOfPositions = 7},
                            new KineticSculptureDisc {InitialPosition = 0, NumOfPositions = 11},

                       };

            var kineticSculpture = new KineticSculpture(discs);

            while (!kineticSculpture.StartSimulation(timeToPressButton))
            {
                timeToPressButton++;
            }

            return timeToPressButton.ToString();
        }
    }
}
