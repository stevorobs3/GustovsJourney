using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.GameObjects
{
    public delegate void ExplodedHandler(TeacupPiecesGameObject pieces);
    
    public class TeacupPiecesGameObject : MonoBehaviour
    {
        public event ExplodedHandler Exploded;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Reset(Transform teacupParent)
        {
            transform.position = teacupParent.position;
            transform.parent = teacupParent;
            transform.rotation = Quaternion.identity;
            _animator.Rebind();
        }

        public void NotifyExploded()
        {
            if (Exploded != null)
                Exploded(this);
        }

        public class Pool : MonoMemoryPool<Transform, TeacupPiecesGameObject>
        {
            protected override void Reinitialize(Transform teacupParent, TeacupPiecesGameObject teacup)
            {
                teacup.Reset(teacupParent);
            }
        }

        private Animator _animator;
    }
}