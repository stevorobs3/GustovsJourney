using OnsightGames.Gustov.Controllers;
using UnityEngine.UI;
using Zenject;

namespace OnsightGames.Gustov.GameObjects
{
    public class GustovStats : CanvasGameObject
    {
        public void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void Update()
        {
            _text.text = _gustov.Velocity.ToString();
        }

        [Inject]
        void Create(GustovGameObject gustov, CanvasController canvasController)
        {
            _gustov = gustov;
            _canvasController = canvasController;
        }

        private GustovGameObject _gustov;
        private CanvasController _canvasController;
        private Text _text;
    }
}