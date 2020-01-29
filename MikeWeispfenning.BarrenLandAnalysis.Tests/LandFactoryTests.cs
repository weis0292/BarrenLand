using Microsoft.VisualStudio.TestTools.UnitTesting;
using MikeWeispfenning.BarrenLandAnalysis.Application.Factories;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class LandFactoryTests
    {
        [TestMethod]
        public void Should_ReturnLand_When_LandDefinitionIsValid()
        {
            var landDefinition = new Rectangle(new Point(0, 0), new Point(400, 600));
            var land = new LandFactory().CreateLand(landDefinition);

            Assert.AreEqual(400, land.ColumnsOfLand);
            Assert.AreEqual(600, land.RowsOfLand);
        }
    }
}
