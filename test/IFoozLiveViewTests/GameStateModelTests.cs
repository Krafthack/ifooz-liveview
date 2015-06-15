using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFoozLiveView.Models;
using IFoozLiveView.Services;
using Xunit;

namespace IFoozLiveViewTests
{

    public class GameStateModelTests
    {

        private readonly TestData _testRepo;

        public GameStateModelTests()
        {
            _testRepo = new TestData();
        }

      


        [Fact]
        public void CreateModelWith6BlueGoals_VerifiesScoreIsCorrect()
        {
            // Arrange
            var goalCount = 6;


            var gamestate = _testRepo.SetupGameState(blueGoals: goalCount);

            // Act
            var score = gamestate.Blue.Score;

            // Assert
            Assert.Equal(score, goalCount);
        }

        [Fact]
        public void CreateModelWith3WhiteGoals_VerifiesScoreIsCorrect()
        {
            // Arrange
            var goalCount = 3;


            var gamestate = _testRepo.SetupGameState(blueGoals: 5, whiteGoals:goalCount);

            // Act
            var score = gamestate.White.Score;

            // Assert
            Assert.Equal(score, goalCount);
        }

        [Fact]
        public void CreateModelWith9TotalGoals_VerifiesScoreIsCorrect()
        {
            // Arrange
            var whiteGoals = 3;
            var blueGoals = 6;


            var gamestate = _testRepo.SetupGameState(blueGoals: blueGoals, whiteGoals:whiteGoals);

            // Act
            var score = gamestate.White.Score + gamestate.Blue.Score;

            // Assert
            Assert.Equal(score, whiteGoals+blueGoals);
        }

    }

}
