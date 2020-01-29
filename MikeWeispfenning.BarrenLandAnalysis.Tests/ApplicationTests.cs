using Microsoft.VisualStudio.TestTools.UnitTesting;
using MikeWeispfenning.BarrenLandAnalysis.Application;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void Should_ReturnSampleOutput_When_SampleInputOneIsProvided()
        {
            var plotToSalt = new string[] { "0 292 399 307" };
            var sampleOutput = Program.GetFertileLandsAsOrderedString(plotToSalt);

            Assert.AreEqual("116800 116800", sampleOutput);
        }

        [TestMethod]
        public void Should_ReturnSampleOutput_When_SampleInputTwoIsProvided()
        {
            var plotsToSalt = new string[] { "48 192 351 207", "48 392 351 407", "120 52 135 547", "260 52 275 547" };
            var sampleOutput = Program.GetFertileLandsAsOrderedString(plotsToSalt);

            Assert.AreEqual("22816 192608", sampleOutput);
        }
    }
}
