using UnityEngine;

namespace OnsightGames.Gustav.Components
{
    public class Grounded : MonoBehaviour
    {
        public void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void OnCollisionEnter2D(Collision2D col)
        {
            if (Mathf.Abs(col.collider.bounds.max.y - _collider.bounds.min.y) < _tolerance)
                _grounded = true;
        }

        public void OnCollisionExit2D(Collision2D col)
        {
            _grounded = false;
        }

        public void OnCollisionStay2D(Collision2D col)
        {
            _grounded = Mathf.Abs(col.collider.bounds.max.y - _collider.bounds.min.y) < _tolerance;
        }

        public bool IsGrounded
        {
            get
            {
                return _grounded;
            }
        }

        private bool _grounded;
        private Collider2D _collider;
        private float _tolerance = 0.02f;
    }
}