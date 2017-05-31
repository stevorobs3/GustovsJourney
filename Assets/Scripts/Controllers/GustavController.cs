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
        }

        private GustavGameObject _gustav;

        // walking Configuration
        private float _walkSpeed = 3f;
        private float _walkAcceleration = 15f;

        // running Configuration
        private float _runSpeed = 10f;
        private float _runAcceleration = 50f;

        // flying configuration
        private float _flyForce = 1.5f;

    }
}