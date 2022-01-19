using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models.ScrambleCommands;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void TestSwapPositionCommand()
        {
            var command = new SwapPositionCommand(new object[] { 4, 0 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("ebcda", output);
        }

        [TestMethod]
        public void TestSwapLetterCommand()
        {
            var command = new SwapLetterCommand(new object[] { 'd', 'b' });

            string input = "ebcda";
            string output = command.Execute(input);

            Assert.AreEqual("edcba", output);
        }

        [TestMethod]
        public void TestRotateCommand1()
        {
            var command = new RotateCommand(new object[] { "left", 1 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("bcdea", output);
        }

        [TestMethod]
        public void TestRotateCommand2()
        {
            var command = new RotateCommand(new object[] { "right", 1 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("eabcd", output);
        }

        [TestMethod]
        public void TestRotateCommand3()
        {
            var command = new RotateCommand(new object[] { "left", 6 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("bcdea", output);
        }

        [TestMethod]
        public void TestRotateCommand4()
        {
            var command = new RotateCommand(new object[] { "right", 3 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("cdeab", output);
        }
        [TestMethod]
        public void TestRotateBasedPositionCommand1()
        {
            var command = new RotateBasedPositionCommand(new object[] { 'b' });

            string input = "abdec";
            string output = command.Execute(input);

            Assert.AreEqual("ecabd", output);

        }

        [TestMethod]
        public void TestRotateBasedPositionCommand2()
        {
            var command = new RotateBasedPositionCommand(new object[] { 'd' });

            string input = "ecabd";
            string output = command.Execute(input);

            Assert.AreEqual("decab", output);
        }

        [TestMethod]
        public void TestReversePositionCommand1()
        {
            var command = new ReversePositionCommand(new object[] { 0, 4 });
            string input = "edcba";
            string output = command.Execute(input);

            Assert.AreEqual("abcde", output);
        }

        [TestMethod]
        public void TestReversePositionCommand2()
        {
            var command = new ReversePositionCommand(new object[] { 2, 5 });
            string input = "abcdefghi";
            string output = command.Execute(input);

            Assert.AreEqual("abfedcghi", output);
        }

        [TestMethod]
        public void TestMovePositionCommand1()
        {
            var command = new MovePositionCommand(new object[] { 1, 4 });
            string input = "bcdea";
            string output = command.Execute(input);

            Assert.AreEqual("bdeac", output);

        }

        [TestMethod]
        public void TestMovePositionCommand2()
        {
            var command = new MovePositionCommand(new object[] { 3, 0 });
            string input = "bdeac";
            string output = command.Execute(input);

            Assert.AreEqual("abdec", output);
        }
    }
}
