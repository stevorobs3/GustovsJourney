using UnityEngine;

namespace OnsightGames.Gustav.GameObjects
{
    public class TeabagGameObject : MonoBehaviour
    {
        public delegate void CollectedHandler();
        public event CollectedHandler Collected;
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<GustavGameObject>() != null)
            {
                if (Collected != null)
                    Collected();
                Destroy(gameObject);
            }                   
        }
    }
}