using OnsightGames.Gustav.Components;
using UnityEngine;

namespace OnsightGames.Gustav.GameObjects
{
    public delegate void DeadHandler();

    public class GustavGameObject : MonoBehaviour
    {
        public event DeadHandler Dead;

        public void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _grounded = GetComponent<Grounded>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            if (_grounded.IsGrounded)
            {
                _rigidBody.velocity -= _rigidBody.velocity.normalized * _deceleration * Time.deltaTime;
                if (_rigidBody.velocity.magnitude < 0.1f)
                    _rigidBody.velocity = Vector2.zero;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _rigidBody.velocity;
            }
        }

        public void AddForce(Vector2 velocityDelta)
        {
            _animator.SetTrigger(FlyingTrigger);
            _rigidBody.velocity += velocityDelta;
            PointSpriteInDirectionOfTravel();
        }

        public void AddVelocity(Vector2 velocityDelta, float maxHorizontalSpeed)
        {
            if (_grounded.IsGrounded)
                _animator.SetTrigger(WalkingTrigger);
            _rigidBody.velocity += velocityDelta;
            _rigidBody.velocity = new Vector2(MinAbs(maxHorizontalSpeed, _rigidBody.velocity.x), _rigidBody.velocity.y);
            PointSpriteInDirectionOfTravel();
        }

        public void Die()
        {
            _animator.SetTrigger(DieingTrigger);
        }

        public void NotifyDead()
        {
            if (Dead != null)
                Dead();
        }

        public void Spawn(Vector3 position)
        {
            transform.position = position;
            _animator.SetTrigger(RespawnTrigger);
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

        private float _deceleration = 10f;

        private const string FlyingTrigger  = "Fly";
        private const string WalkingTrigger = "Walk";
        private const string DieingTrigger  = "Die";
        private const string RespawnTrigger = "Respawn";

        private Rigidbody2D _rigidBody;
        private SpriteRenderer _spriteRenderer;
        private Grounded _grounded;
        private Animator _animator;
    }
}