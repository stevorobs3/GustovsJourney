using OnsightGames.Gustav.GameObjects;
using UnityEngine;
using OnsightGames.Gustav.Models;

namespace OnsightGames.Gustav.Controllers
{
    public class GustavController : IGustavController
    {
        public GustavController(GustavGameObject gustav)
        {
            _gustav = gustav;
            _lastJumpTime = _timeBetweenJumps;
        }

        public void Move(GustavDirection direction, float deltaTime, bool isRunning)
        {
            var moveDirection = direction == GustavDirection.Left ? Vector2.left : Vector2.right;
            var speed = isRunning ? _runSpeed : _walkSpeed;
            var acceleration = isRunning ? _runAcceleration : _walkAcceleration;
            var velocityDelta = moveDirection * acceleration * deltaTime;
            _gustav.AddVelocity(velocityDelta, speed);
        }

        public void Jump()
        {
            if (!_gustav.IsJumping & TimeSinceLastJump() > _timeBetweenJumps)
            {
                _lastJumpTime = Time.time;
                _gustav.AddForce(Vector2.up * _jumpForce);
            }
        }

        private float TimeSinceLastJump()
        {
            return Time.time - _lastJumpTime;
        }

        private GustavGameObject _gustav;

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