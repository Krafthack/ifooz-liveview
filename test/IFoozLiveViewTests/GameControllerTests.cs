using IFoozLiveView.Controllers;
using IFoozLiveView.Services;
using Microsoft.AspNet.Mvc;
using Xunit;


namespace IFoozLiveViewTests
{
    public class GameControllerTests
    {
        private GameController _gameController;
        private IGameStateService _gameStateServiceMock;
        private readonly TestData _testRepo;


        public GameControllerTests()
        {
            _gameStateServiceMock = new GameStateTestData();
            _gameController = new GameController();
            _testRepo = new TestData();

            _gameController.GameStateService = _testRepo;

        }

        


        [Fact]
        public void Index_ReturnsTypeView()
        {
            // Act
            var result = _gameController.Index();

            // Assert
            Assert.Equal(typeof(ViewResult), result.GetType());
        }

        [Fact]
        public void RetrieveGameState_ReturnsTypeJson()
        {
            // Act
            var result = _gameController.RetrieveGameState();

            // Assert
            Assert.Equal(typeof(JsonResult), result.GetType());
        }

        [Fact]
        public void RetrieveGameState_ReturnsJson_PlayerTeamName_EqualsTeamName()
        {
            // Act
            dynamic result = _gameController.RetrieveGameState();

            dynamic json = result.Value;

            // Assert
            Assert.Equal(json.Blue.Name, json.Blue.Goals[0].Team);
        }
    }
}
