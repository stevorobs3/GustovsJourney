using UnityEngine;

namespace OnsightGames.Gustav.GameObjects
{
    public class PlatformGameObject : MonoBehaviour
    {
        public void Awake()
        {
            Collider = GetComponent<BoxCollider2D>();
        }

        public BoxCollider2D Collider;

    }
}