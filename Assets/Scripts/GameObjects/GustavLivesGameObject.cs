using UnityEngine;

namespace OnsightGames.Gustav.GameObjects
{
    public class GustavLivesGameObject : CanvasGameObject
    {
        public void Display(int numLives)
        {
            var numLivesToDisplay = Mathf.Min(LifeVisuals.Length, numLives);
            for(int i = 0; i < LifeVisuals.Length; i++)
            {
                LifeVisuals[i].SetActive(i < numLivesToDisplay);
            }
        }

        public GameObject[] LifeVisuals;
    }
}