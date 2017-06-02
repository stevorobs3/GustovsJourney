using OnsightGames.Gustav.GameObjects;
using UnityEngine;
using OnsightGames.Gustav.Models;

namespace OnsightGames.Gustav.Controllers
{
    public class GustavController : IGustavController
    {
        public GustavController(
            GustavGameObject gustav,
            GustavLivesGameObject gustavLives,
            GameOverTextGameObject gameOverText
        )
        {
            _gustav      = gustav;
            _gustavLives = gustavLives;
            _gameOverText = gameOverText;

            UpdateLives(InitialLives);
        }

        public void Move(GustavDirection direction, float deltaTime, bool isRunning)
        {
            var moveDirection = direction == GustavDirection.Left ? Vector2.left : Vector2.right;
            var speed = isRunning ? _runSpeed : _walkSpeed;
            var acceleration = isRunning ? _runAcceleration : _walkAcceleration;
            var velocityDelta = moveDirection * acceleration * deltaTime;
            _gustav.AddVelocity(velocityDelta, speed);
        }

        public void Fly()
        {
            _gustav.AddForce(Vector2.up * _flyForce);
        }

        public void Die()
        {
            Debug.Log("gustav died!");
            UpdateLives(_lives - 1);
            if (_lives >= 0)
                _gustav.Dead += RespawnGustav;
            else
                _gustav.Dead += EndGame;
            _gustav.Die();
        }

        private void RespawnGustav()
        {
            _gustav.Dead -= RespawnGustav;
            _gustav.Spawn(new Vector3(-3,-3));
        }

        private void EndGame()
        {
            _gustav.Dead -= EndGame;
            _gameOverText.Show();
        }

        private void UpdateLives(int numLives)
        {
            _lives = numLives;
            _gustavLives.Display(numLives - 1);
        }

        private GustavGameObject _gustav;
        private GustavLivesGameObject _gustavLives;
        private GameOverTextGameObject _gameOverText;

        // walking Configuration
        private float _walkSpeed = 3f;
        private float _walkAcceleration = 15f;

        // running Configuration
        private float _runSpeed = 10f;
        private float _runAcceleration = 50f;

        // flying configuration
        private float _flyForce = 1.5f;

        // lives configuration
        private const int InitialLives = 5;
        private int _lives;

    }
}