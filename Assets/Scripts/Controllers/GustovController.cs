using OnsightGames.Gustov.GameObjects;
using UnityEngine;
using OnsightGames.Gustov.Models;

namespace OnsightGames.Gustov.Controllers
{
    public class GustovController : IGustovController
    {
        public GustovController(GustovGameObject gustov)
        {
            _gustov = gustov;
            _lastJumpTime = _timeBetweenJumps;
        }

        public void Move(GustovDirection direction, float deltaTime, bool isRunning)
        {
            var moveDirection = direction == GustovDirection.Left ? Vector2.left : Vector2.right;
            var speed = isRunning ? _runSpeed : _walkSpeed;
            var acceleration = isRunning ? _runAcceleration : _walkAcceleration;
            var velocityDelta = moveDirection * acceleration * deltaTime;
            _gustov.AddVelocity(velocityDelta, speed);
        }

        public void Jump()
        {
            if (!_gustov.IsJumping & TimeSinceLastJump() > _timeBetweenJumps)
            {
                _lastJumpTime = Time.time;
                _gustov.AddForce(Vector2.up * _jumpForce);
            }
        }

        private float TimeSinceLastJump()
        {
            return Time.time - _lastJumpTime;
        }

        private GustovGameObject _gustov;

        // walking Configuration
        private float _walkSpeed = 5f;
        private float _walkAcceleration = 35f;

        // running Configuration
        private float _runSpeed = 10f;
        private float _runAcceleration = 50f;

        // jumping configuration
        private float _jumpForce = 7.9f;

        private float _lastJumpTime;
        private float _timeBetweenJumps = 0.2f;

    }
}