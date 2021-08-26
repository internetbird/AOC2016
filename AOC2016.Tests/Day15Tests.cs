using AOC2016.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void TestKineticSculpture1()
        {
            var discs = new KineticSculptureDisc[]
            {
                  new KineticSculptureDisc {InitialPosition = 4, NumOfPositions = 5},
                  new KineticSculptureDisc {InitialPosition = 1, NumOfPositions = 2},
            };

            var kineticSculpture = new KineticSculpture(discs);

            bool success = kineticSculpture.StartSimulation(0);
            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void TestKineticSculpture2()
        {
            var discs = new KineticSculptureDisc[]
            {
                  new KineticSculptureDisc {InitialPosition = 4, NumOfPositions = 5},
                  new KineticSculptureDisc {InitialPosition = 1, NumOfPositions = 2},
            };

            var kineticSculpture = new KineticSculpture(discs);

            bool success = kineticSculpture.StartSimulation(5);
            Assert.AreEqual(true, success);
        }
    }
}
