using UnityEngine;

namespace OnsightGames.Gustov.GameObjects
{
    public class IsabelleGameObject : MonoBehaviour
    {
        public delegate void CollectedHandler();
        public event CollectedHandler Collected;
        public void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("Isabelle triggered");
            if (col.GetComponent<GustovGameObject>() != null)
            {
                if (Collected != null)
                    Collected();
            }
        }
    }
}