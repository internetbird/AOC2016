using AOC2016.Logic;
using AOC2016.Utility;
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

        [TestMethod]
        public void TestV2Case1()
        {
            var input = "(3x3)XYZ";

            var decompressor = new EasterBunnyDecompressor();

            long decompressedTextLength = decompressor.DecompressTextV2(input);

            Assert.AreEqual(decompressedTextLength, "XYZXYZXYZ".Length);
        }

        [TestMethod]
        public void TestV2Case2()
        {
            var input = "X(8x2)(3x3)ABCY";

            var decompressor = new EasterBunnyDecompressor();

            long decompressedTextLength = decompressor.DecompressTextV2(input);

            Assert.AreEqual(decompressedTextLength, "XABCABCABCABCABCABCY".Length);
        }

        [TestMethod]
        public void TestV2Case3()
        {
            var input = "(27x12)(20x12)(13x14)(7x10)(1x12)A";

            var decompressor = new EasterBunnyDecompressor();

            long decompressedTextLength = decompressor.DecompressTextV2(input);

            Assert.AreEqual(decompressedTextLength, 241920);
        }

        [TestMethod]
        public void TestV2Case4()
        {
            var input = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";

            var decompressor = new EasterBunnyDecompressor();

            long decompressedTextLength = decompressor.DecompressTextV2(input);

            Assert.AreEqual(decompressedTextLength, 445);
        }
    }
}
