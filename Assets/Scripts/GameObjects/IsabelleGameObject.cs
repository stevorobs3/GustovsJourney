using UnityEngine;

namespace OnsightGames.Gustav.GameObjects
{
    public class IsabelleGameObject : MonoBehaviour
    {
        public delegate void CollectedHandler();
        public event CollectedHandler Collected;
        public void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("Isabelle triggered");
            if (col.GetComponent<GustavGameObject>() != null)
            {
                if (Collected != null)
                    Collected();
            }
        }
    }
}