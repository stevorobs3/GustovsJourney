using OnsightGames.Gustov.Controllers;
using Zenject;

namespace OnsightGames.Gustov.Services
{
    public class LevelController : ILevelController
    {
        public LevelController(
            IIsabelleController isabelle,
            ILevelTimerController levelTimer
        )
        {
            _isabelleController = isabelle;
            _levelTimer = levelTimer;
            isabelle.Collected += PauseTimer;
        }

        private void PauseTimer()
        {
            _levelTimer.StopTimer();
        }

        private IIsabelleController _isabelleController;
        private ILevelTimerController _levelTimer;
    }
}