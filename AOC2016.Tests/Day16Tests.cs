using AOC2016.Logic.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day16Tests
    {

        [TestMethod]
        public void DragonChecksumCalculatorTest1()
        {
            var checksumCalculator = new DragonChecksumCalculator();
            string checksum = checksumCalculator.CalculateChecksum("110010110100", 12);

            Assert.AreEqual("100", checksum);

        }

        [TestMethod]
        public void DragonChecksumCalculatorTest2()
        {
            var checksumCalculator = new DragonChecksumCalculator();
            string checksum = checksumCalculator.CalculateChecksum("10000", 20);

            Assert.AreEqual("01100", checksum);
        }

    }
}
