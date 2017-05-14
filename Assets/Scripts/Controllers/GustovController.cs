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

        public void Move(GustovDirection direction, float deltaTime)
        {
            var moveDirection = direction == GustovDirection.Left ? Vector2.left : Vector2.right;
            var velocityDelta = moveDirection * _walkAcceleration * deltaTime;
            _gustov.AddVelocity(velocityDelta, _walkSpeed);
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
        private float _walkAcceleration = 30f;

        // jumping configuration
        private float _jumpForce = 7.8f;

        private float _lastJumpTime;
        private float _timeBetweenJumps = 0.2f;

    }
}