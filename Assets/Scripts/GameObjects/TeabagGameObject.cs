using UnityEngine;

namespace OnsightGames.Gustov.GameObjects
{
    public class TeabagGameObject : MonoBehaviour
    {
        public delegate void CollectedHandler();
        public event CollectedHandler Collected;
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<GustovGameObject>() != null)
            {
                if (Collected != null)
                    Collected();
                Destroy(gameObject);
            }                   
        }
    }
}