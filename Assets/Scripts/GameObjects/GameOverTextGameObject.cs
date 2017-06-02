using UnityEngine;
using UnityEngine.UI;

namespace OnsightGames.Gustav.GameObjects
{
    public class GameOverTextGameObject : CanvasGameObject
    {
        public void Awake()
        {
            _text = GetComponent<Text>();
            Hide();            
        }
        public void Show()
        {
            _text.enabled = true;
        }

        public void Hide()
        {
            _text.enabled = false;
        }

        private Text _text;
    }
}