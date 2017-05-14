using OnsightGames.Gustov.Components;
using UnityEngine;

namespace OnsightGames.Gustov.GameObjects
{
    public class GustovGameObject : MonoBehaviour
    {
        public void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _grounded = GetComponent<Grounded>();
        }

        public Vector2 Velocity
        {
            get
            {
                return _rigidBody.velocity;
            }
        }

        public bool IsJumping
        {
            get
            {
                return !_grounded.IsGrounded;
            }
        }

        public void AddForce(Vector2 velocityDelta)
        {
            _rigidBody.velocity += velocityDelta;
            PointSpriteInDirectionOfTravel();
        }

        public void AddVelocity(Vector2 velocityDelta, float maxHorizontalSpeed)
        {
            _rigidBody.velocity += velocityDelta;
            _rigidBody.velocity = new Vector2(MinAbs(maxHorizontalSpeed, _rigidBody.velocity.x), _rigidBody.velocity.y);
            PointSpriteInDirectionOfTravel();
        }

        private static float MinAbs(float max, float original)
        {
            return Mathf.Min(Mathf.Abs(original), Mathf.Abs(max)) * Mathf.Sign(original); ;
        }


        private void PointSpriteInDirectionOfTravel()
        {
            if (Mathf.Abs(_rigidBody.velocity.x) > 0.00001f)
            {
                var original = _spriteRenderer.transform.localScale;
                var newX = _rigidBody.velocity.x > 0f ? -1f : 1f;
                _spriteRenderer.transform.localScale = new Vector3(newX, original.y, original.z); 
            }            
        }

        private Rigidbody2D _rigidBody;
        private SpriteRenderer _spriteRenderer;
        private Grounded _grounded;
    }
}