using System.Collections;
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

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                return _spriteRenderer;
            }
        }

        public void Awake()
        {
            _animator       = GetComponent<Animator>();
            _rigidbody      = GetComponent<Rigidbody2D>();
            _teaSplash      = GetComponentInChildren<ParticleSystem>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider       = GetComponent<Collider2D>();
        }

        public void Reset(Vector3 spawnPosition)
        {
            Debug.Log("resetting!");
            transform.position = spawnPosition;
            transform.rotation = Quaternion.identity;

            if (_cupHasBeenEmptied)
            {
                Debug.Log("cup empty thing shit");
                _animator.ResetTrigger(EmptyCupTrigger);
            }

            if (_cupFilled) {
                Debug.Log("Setting empty trigger");
                _animator.ResetTrigger(FillCupTrigger);
                _animator.SetTrigger(EmptyCupTrigger);
                _cupHasBeenEmptied = true;
            }

            
            _isEmpty = true;
            _cupFilled = false;
            _spriteRenderer.enabled = true;
            _collider.enabled = true;
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
                    _teaSplash.Play();
                    StartCoroutine(DelayFillCup(_teaSplash.main.duration));
                    
                    if (CupFilled != null)
                        CupFilled(this);
                    DisableAI();
                }
                else if (_isEmpty)
                {
                    _spriteRenderer.enabled = false;
                    _collider.enabled = false;
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

        private IEnumerator DelayFillCup(float delay)
        {
            yield return new WaitForSeconds(delay);
            _animator.SetTrigger(FillCupTrigger);
            _cupFilled = true;
        }

        private void DisableAI()
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = 1f;
            _rigidbody.drag = 0.5f;
        }

        private bool _isEmpty = true;
        private bool _cupFilled = false;
        private bool _cupHasBeenEmptied = false;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private ParticleSystem _teaSplash;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;

        private const string EmptyCupTrigger = "EmptyCup";
        private const string FillCupTrigger = "FillCup";
    }
}