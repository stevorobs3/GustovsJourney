using UnityEngine;

namespace OnsightGames.Gustov.GameObjects
{
    public class GustovGameObject : MonoBehaviour
    {
        public void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<PolygonCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            if (_maxVelocity != null)
                NormaliseVelocity((Vector2)_maxVelocity);
        }

        public bool IsJumping
        {
            get
            {
                //TODO: this means that its true at top of jump!
                return Mathf.Abs(_rigidBody.velocity.y) != 0f;
            }
        }

        public void ApplyForce(Vector2 force, Vector2 maxVelocity)
        {
            _maxVelocity = maxVelocity;
            _rigidBody.AddForce(force);
            NormaliseVelocity(maxVelocity);
            PointSpriteInDirectionOfTravel();
        }

        private void NormaliseVelocity(Vector2 maxVelocity)
        {
            var newX = MinAbs(maxVelocity.x, _rigidBody.velocity.x);
            var newY = MinAbs(maxVelocity.y, _rigidBody.velocity.y);
            _rigidBody.velocity = new Vector2(newX, newY);
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

        private static float MinAbs(float max, float original)
        {
            return Mathf.Min(Mathf.Abs(original), Mathf.Abs(max)) * Mathf.Sign(original);
        }

        private Rigidbody2D _rigidBody;
        private SpriteRenderer _spriteRenderer;
        private PolygonCollider2D _collider;

        // Current max velocity (different if running / walking)
        private Vector2? _maxVelocity;
    }
}