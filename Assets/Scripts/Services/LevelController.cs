using OnsightGames.Gustav.Controllers;
using Zenject;

namespace OnsightGames.Gustav.Services
{
    public class LevelController : ILevelController
    {
        public LevelController(
            ILevelTimerController levelTimer
        )
        {
            _levelTimer = levelTimer;
        }

        private ILevelTimerController _levelTimer;
    }
}