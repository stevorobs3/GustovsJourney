using OnsightGames.Gustov.GameObjects;

namespace OnsightGames.Gustov.Controllers
{
    public class ScoreController : IScoreController
    {
        public ScoreController(ScoreDisplay scoreDisplay)
        {
            _scoreDisplay = scoreDisplay;
        }

        public void Score()
        {
            _score += 1;
            _scoreDisplay.Display(_score);
        }
        
        private ScoreDisplay _scoreDisplay;

        private int _score = 0;

    }
}