using UnityEngine;
using UnityEngine.UI;

namespace OnsightGames.Gustav.GameObjects
{
    public class LevelTimerGameObject : CanvasGameObject
    {
        public void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void Display(string time)
        {
            _text.text = time;
        }

        private Text _text;
        
    }
}