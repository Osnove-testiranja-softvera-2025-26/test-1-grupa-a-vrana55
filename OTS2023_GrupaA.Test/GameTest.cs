using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaA.Test
{
    internal class Class1
    {
        namespace OTS2026_GrupaA.Test
        [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void F1_ValidPlayerAndRevealPosition_NoException()
        {
            var playerPos = new Position(0, 0, 0);
            var revealPos = new Position(1, 0, 0);

            Assert.DoesNotThrow(() => _game.InitializeGame(playerPos, revealPos));
        }
        [Test]
        public void F1_PlayerPositionOutsideMap_ThrowsException()
        {
            var playerPos = new Position(30, 0, 0);
            var revealPos = new Position(1, 0, 0);

            Assert.Throws<PositionOutsideOfMapException>(
                () => _game.InitializeGame(playerPos, revealPos));
        }

        [Test]
        public void F1_NegativeCoordinates_ThrowsException()
        {
            var playerPos = new Position(-1, 0, 0);
            var revealPos = new Position(0, 0, 0);

            Assert.Throws<PositionOutsideOfMapException>(
                () => _game.InitializeGame(playerPos, revealPos));

        
        [Test]
            public void F5_StandardGoldExactly15_WithReveal_ScoreIsBad()
            {
  
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));
                _game.SetPlayerForTest(new Player
                {
                    HiddenGold = 0,
                    StandardGold = 15,
                    HasRevealHiddenItem = true
                });

                Assert.That(_game.CalculateScore(), Is.EqualTo(Score.Bad));
            }

        [Test]
            public void F5_HiddenGoldExactly10_StandardGold20_RevealTrue_NotGood()
            { 
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));
                _game.SetPlayerForTest(new Player)
                {
                    HiddenGold = 10,
                    StandardGold = 20,
                    HasRevealHiddenItem = true
                });
                Assert.That(_game.CalculateScore(), Is.EqualTo(Score.Good));
            }

        [Test]
            public void F4_CollectGoldFromHiddenTile_HiddenGoldIncreasesNotStandard()
            {
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));
                _game.MovePlayer(Move.Right);
                _game.MovePlayer(Move.Right);
                _game.CollectItems(); 
                _game.MovePlayer(Move.Up); 

                int beforeHidden = _game.Player.HiddenGold;
                int beforeStandard = _game.Player.StandardGold;

                _game.CollectItems();

                Assert.That(_game.Player.HiddenGold, Is.GreaterThan(beforeHidden));
                Assert.That(_game.Player.StandardGold, Is.EqualT(beforeStandard));
            }

        [Test]
            public void F4_CollectRevealHiddenItem_PlayerFlagSetAndTileEmpty()
            {
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));
                _game.MovePlayer(Move.Right);
                _game.MovePlayer(Move.Right);

                _game._game.CollectItems(); 

                Assert.IsTrue(_game.Player.HasRevealHiddenItem);
                Assert.That(
                    _game.Space.GetTile(new Position(2, 0, 0)).Content,
                    Is.EqualTo(TileContent.Empty));
            }

        [Test]
            public void F3_StandardTile_IsAlwaysValid()
            {
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));

                _game._game.CollectItems(); 
                Assert.IsTrue(_game.ValidatePosition(new Position(1, 0, 0));
            }

        [Test]
            public void F3_MapBarrierTile_IsNeverValid()
            {
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));

                Assert.IsFalse(_game.ValidatePosition(new Position(6, 10, 3)));
            }

        [Test]
            public void F3_HiddenTile_WithoutRevealItem_IsNotValid()
            {
                _game.InitializeGame(new Position(0, 0, 0), new Position(2, 0, 0));

                _game._game.CollectItems();

                Assert.IsFalse(_game.ValidatePosition(new Position(0, 0, 15)));

            }

            [Test]

            public void

















        }

    }
}
