using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.GameObjects
{
    public delegate void HitGustavHandler(TeacupGameObject teacup);
    
    public class TeacupGameObject : MonoBehaviour
    {
        public event HitGustavHandler CupFilled;
        public event HitGustavHandler CollidedWithGustav;
        public event HitGustavHandler CollectedByGustav;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Reset(Vector3 spawnPosition)
        {
            Debug.Log("resetting!");
            transform.position = spawnPosition;

            if (_cupHasBeenEmptied)
            {
                Debug.Log("cup empty thing shit");
                _animator.ResetTrigger(EmptyCupTrigger);
            }

            if (!_isEmpty) {
                Debug.Log("Setting empty trigger");
                _animator.ResetTrigger(FillCupTrigger);
                _animator.SetTrigger(EmptyCupTrigger);
                _cupHasBeenEmptied = true;
            }

            
            _isEmpty = true;
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        public class Pool : MonoMemoryPool<Vector3, TeacupGameObject>
        {
            protected override void Reinitialize(Vector3 spawnPosition, TeacupGameObject teacup)
            {
                teacup.Reset(spawnPosition);
            }
        }

        public void OnCollisionEnter2D(Collision2D collider)
        {
            var gustav = collider.gameObject.GetComponent<GustavGameObject>();
            if (gustav != null)
            {
                bool hitfillsCup = gustav.transform.position.y >= transform.position.y;
                if (_isEmpty && hitfillsCup)
                {
                    _isEmpty = false;
                    _animator.SetTrigger(FillCupTrigger);
                    if (CupFilled != null)
                        CupFilled(this);
                    DisableAI();
                }
                else if (_isEmpty)
                {
                    if (CollidedWithGustav != null)
                        CollidedWithGustav(this);
                }
                else
                {
                    if (CollectedByGustav != null)
                        CollectedByGustav(this);
                }
            }
        }

        private void DisableAI()
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = 1f;
        }

        private bool _isEmpty = true;
        private bool _cupHasBeenEmptied = false;
        private Animator _animator;
        private Rigidbody2D _rigidbody;

        private const string EmptyCupTrigger = "EmptyCup";
        private const string FillCupTrigger = "FillCup";
    }
}