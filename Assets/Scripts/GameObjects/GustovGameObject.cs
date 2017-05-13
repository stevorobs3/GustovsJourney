using UnityEngine;

namespace OnsightGames.Gustov.GameObjects
{
    public class GustovGameObject : MonoBehaviour
    {
        public void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

        }

        public void ApplyForce(Vector3 force, Vector2 maxVelocity)
        {
            Debug.Log("Apply force " + force);
            _rigidBody.AddForce(force);
            NormaliseVelocity(maxVelocity);
            PointSpriteInDirectionOfTravel();
        }

        private void NormaliseVelocity(Vector2 maxVelocity)
        {
            var newX = MinAbs(maxVelocity.x, _rigidBody.velocity.x);
            var newY = MinAbs(maxVelocity.y, _rigidBody.velocity.y);
            _rigidBody.velocity = new Vector3(newX, newY, _rigidBody.velocity.z);
        }

        private void PointSpriteInDirectionOfTravel()
        {
            if (Mathf.Abs(_rigidBody.velocity.x) > 0.00001f)
                _spriteRenderer.flipX = _rigidBody.velocity.x > 0f;
        }

        private static float MinAbs(float max, float original)
        {
            return Mathf.Min(Mathf.Abs(original), Mathf.Abs(max)) * Mathf.Sign(original);
        }

        private Rigidbody _rigidBody;
        private SpriteRenderer _spriteRenderer;
    }
}