using UnityEngine;
using UnityEngine.UI;

namespace OnsightGames.Gustav.GameObjects
{
    public class ScoreDisplay : CanvasGameObject
    {
        public void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void Display(int score)
        {
            _text.text = score.ToString();
        }
            

        private Text _text;
    }
}