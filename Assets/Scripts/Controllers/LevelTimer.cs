using System;
using OnsightGames.Gustav.GameObjects;
using Zenject;
using UnityEngine;

namespace OnsightGames.Gustav.Controllers
{
    public class LevelTimerController : ILevelTimerController, ITickable
    {
        public LevelTimerController(LevelTimerGameObject timerDisplay)
        {
            _timerDisplay = timerDisplay;
            StartTimer();
        }

        public void StartTimer()
        {
            _active = true;
            _currentTime = 0f;
        }

        public void StopTimer()
        {
            Debug.Log("Stopping Timer!");
            _active = false;
        }

        public void Tick()
        {
            if (_active)
                _currentTime += Time.deltaTime;
            _timerDisplay.Display(FormatTime(_currentTime));
        }

        private string FormatTime(float currentTime)
        {
            return string.Format("{0:0.0}s", currentTime);
        }

        private LevelTimerGameObject _timerDisplay;
        private float _currentTime;
        private bool _active;


    }
}