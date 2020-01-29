using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class LandTests
    {
        [TestMethod]
        public void Should_HaveSingleCompleteFertilePlot_When_NewLandIsCreated()
        {
            var land = new Land(GetSquareMetersForLand(400, 600));

            Assert.AreEqual(240000, land.FertilePlotsInSquareMeters.Single());
        }

        [TestMethod]
        public void Should_HaveCorrectFertileLand_When_ValidSaltHasBeenAdded_One()
        {
            var land = new Land(GetSquareMetersForLand(400, 600));
            land.AddSalt(new Rectangle(new Point(0, 292), new Point(399, 307)));

            Assert.AreEqual(2, land.FertilePlotsInSquareMeters.Count());
            Assert.AreEqual(116800, land.FertilePlotsInSquareMeters.First());
            Assert.AreEqual(116800, land.FertilePlotsInSquareMeters.Skip(1).First());
        }

        [TestMethod]
        public void Should_HaveCorrectFertileLand_When_ValidSaltHasBeenAdded_Two()
        {
            var land = new Land(GetSquareMetersForLand(400, 600));
            land.AddSalt(new Rectangle(new Point(48, 192), new Point(351, 207)));
            land.AddSalt(new Rectangle(new Point(48, 392), new Point(351, 407)));
            land.AddSalt(new Rectangle(new Point(120, 52), new Point(135, 547)));
            land.AddSalt(new Rectangle(new Point(260, 52), new Point(275, 547)));

            Assert.AreEqual(2, land.FertilePlotsInSquareMeters.Count());
            Assert.IsTrue(land.FertilePlotsInSquareMeters.Contains(22816));
            Assert.IsTrue(land.FertilePlotsInSquareMeters.Contains(192608));
        }

        [TestMethod]
        public void Should_HaveCorrectSize_When_NewLandIsCreated()
        {
            var land = new Land(GetSquareMetersForLand(50, 500));

            Assert.AreEqual(50, land.ColumnsOfLand);
            Assert.AreEqual(500, land.RowsOfLand);
        }

        private SquareMeter[,] GetSquareMetersForLand(int columns, int rows)
        {
            var squareMeters = new SquareMeter[columns, rows];
            for (int y = 0; y < squareMeters.GetLength(1); y++)
            {
                for (int x = 0; x < squareMeters.GetLength(0); x++)
                {
                    squareMeters[x, y] = new SquareMeter();
                }
            }

            return squareMeters;
        }
    }
}
