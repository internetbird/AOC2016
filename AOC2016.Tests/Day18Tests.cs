using AOC2016.Logic.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void TestTilesCalculator1()
        {
            var calculator = new TilesCalculator();

            bool[] tileRow = calculator.ParseTileRow(".^^.^.^^^^");
            bool[] nextTileRow = calculator.CalculateNextTileRow(tileRow);

            string nextRow = calculator.GetTileRowString(nextTileRow);

            Assert.AreEqual("^^^...^..^", nextRow);

        }

        [TestMethod]
        public void TestTilesCalculator2()
        {
            var calculator = new TilesCalculator();

            bool[] tileRow = calculator.ParseTileRow("..^^...^^^");
            bool[] nextTileRow = calculator.CalculateNextTileRow(tileRow);

            int numOfSafeTiles = calculator.GetNumOfSafeTiles(nextTileRow);

            Assert.AreEqual(3, numOfSafeTiles);
        }
    }
}
