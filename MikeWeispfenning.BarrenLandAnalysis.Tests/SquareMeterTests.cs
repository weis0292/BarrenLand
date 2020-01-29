using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class SquareMeterTests
    {
        [TestMethod]
        public void Should_BeFertile_When_NewSquareMeterIsCreated()
        {
            var squareMeter = new SquareMeter();

            Assert.AreEqual(true, squareMeter.IsFertile);
        }

		[TestMethod]
		public void Should_BeBarren_When_SaltIsAdded()
        {
            var squareMeter = new SquareMeter();
            squareMeter.AddSalt();

            Assert.AreEqual(false, squareMeter.IsFertile);
        }
    }
}
