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
        }

        public void Move(GustovDirection direction, float deltaTime)
        {
            var forceDirection = direction == GustovDirection.Left ? Vector2.left : Vector2.right;
            var force = forceDirection * _force * deltaTime;
            _gustov.ApplyForce(force, _maxVelocity);
        }

        private GustovGameObject _gustov;
        private float _force = 1000f;
        private Vector2 _maxVelocity = new Vector2(5f, 5f);
    }
}