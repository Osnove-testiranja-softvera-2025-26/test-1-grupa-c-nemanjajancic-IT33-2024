using NUnit.Framework;
using OTS2026_GrupaC.Exceptions;
using OTS2026_GrupaC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaC.Test
{
    [TestFixture]
    internal class GameTest
    {
        private Game game;
        [SetUp]
        public void Setup()
        {
            Game game = new Game(new Location(1, 1, 1), new Location(3, 3, 3));
        }
            [Test]
            public void LocationOutsideOfBounds()
            {
                Exception ex = Assert.Throws<LocationOutsideOfMapException>((TestDelegate)(() => new Game(new Location(), null)));
                Assert.That(ex.Message, Is.EqualTo("Locations must be valid!"));
            }
            [TestCaseSource(typeof(GameTestData), "MoveUp_SuccessfulMove_PlayerPositionChanged_TestData")]
            public void MoveUp_SuccessfulMove_PlayerPositionChanged(int xCoord, int yCoord, int zCoord, int expectedZCoord)
            {
                game.Player.Location = new Location(xCoord, yCoord, zCoord);
                game.Player.MoveUp();
                Assert.AreEqual(expectedZCoord, game.Player.Location);
            }
        [TestCase(-1, -1, -13)]
        [TestCase(31, 31, 31)]
        [TestCase(12, 23, 0)]
        public void ValidateLocationInsideMap(int xCoord, int yCoord, int zCoord, int expectedLocation)
        {
            game.Player.Location = new Location(xCoord, yCoord, zCoord);
            game.UpdatePlayer();
            Assert.AreEqual(expectedLocation, game.Player.Location);
        }
    }
}
