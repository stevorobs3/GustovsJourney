using OnsightGames.Gustov.GameObjects;
using System.Collections.Generic;

namespace OnsightGames.Gustov.Controllers
{
    public class TeabagController : ITeabagController
    {
        public TeabagController(IScoreController scoreContorller, List<TeabagGameObject> teabags)
        {
            _teabags = teabags;
            _scoreController = scoreContorller;
            for (int i = 0; i < teabags.Count; i++)
            {
                teabags[i].Collected += IncrementScore;
            }
        }

        private void IncrementScore()
        {
            _scoreController.Score();
        }

        private List<TeabagGameObject> _teabags;
        private IScoreController _scoreController;
    }
}