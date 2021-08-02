using AOC2016.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day9Tests
    {
        [TestMethod]
        public void TestNoMarkersString()
        {
            var input = "ADVENT";

            var decompressor = new EasterBunnyDecompressor();

            string decompressedText = decompressor.DecompressText(input);

            Assert.AreEqual(decompressedText, input);
        }

        [TestMethod]
        public void TestCase1()
        {
            var input = "A(1x5)BC";

            var decompressor = new EasterBunnyDecompressor();

            string decompressedText = decompressor.DecompressText(input);

            Assert.AreEqual(decompressedText, "ABBBBBC");
        }

       

        [TestMethod]
        public void TestCase2()
        {
            var input = "(3x3)XYZ";

            var decompressor = new EasterBunnyDecompressor();

            string decompressedText = decompressor.DecompressText(input);

            Assert.AreEqual(decompressedText, "XYZXYZXYZ");
        }

       [TestMethod]
        public void TestCase3()
        {
            var input = "A(2x2)BCD(2x2)EFG";

            var decompressor = new EasterBunnyDecompressor();

            string decompressedText = decompressor.DecompressText(input);

            Assert.AreEqual(decompressedText, "ABCBCDEFEFG");
        }

        [TestMethod]
        public void TestCase4()
        {
            var input = "(6x1)(1x3)A";

            var decompressor = new EasterBunnyDecompressor();

            string decompressedText = decompressor.DecompressText(input);

            Assert.AreEqual(decompressedText, "(1x3)A");
        }
        
       [TestMethod]
       public void TestCase5()
       {
           var input = "X(8x2)(3x3)ABCY";

           var decompressor = new EasterBunnyDecompressor();

           string decompressedText = decompressor.DecompressText(input);

           Assert.AreEqual(decompressedText, "X(3x3)ABC(3x3)ABCY");
       }
    }
}
