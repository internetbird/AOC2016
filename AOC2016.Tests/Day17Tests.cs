using AOC2016.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{

    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void TestRoomsGridNavigator1()
        {
            var navigator = new RoomsGridNavigator("hijkl");
            string shortestPath = navigator.FindShortestPathToVault();

            Assert.AreEqual(string.Empty, shortestPath);
        }


        [TestMethod]
        public void TestRoomsGridNavigator2()
        {
            var navigator = new RoomsGridNavigator("ihgpwlah");
            string shortestPath = navigator.FindShortestPathToVault();

            Assert.AreEqual("DDRRRD", shortestPath);
        }

        [TestMethod]
        public void TestRoomsGridNavigator3()
        {
            var navigator = new RoomsGridNavigator("kglvqrro");
            string shortestPath = navigator.FindShortestPathToVault();

            Assert.AreEqual("DDUDRLRRUDRD", shortestPath);
        }

        [TestMethod]
        public void TestRoomsGridNavigator4()
        {
            var navigator = new RoomsGridNavigator("ulqzkmiv");
            string shortestPath = navigator.FindShortestPathToVault();

            Assert.AreEqual("DRURDRUDDLLDLUURRDULRLDUUDDDRR", shortestPath);
        }


    }
}
