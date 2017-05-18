using OnsightGames.Gustav.Controllers;
using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.GameObjects
{
    public abstract class CanvasGameObject : MonoBehaviour
    {

        [Inject]
        void Create(ICanvasController canvasController)
        {
            _canvasController = canvasController;
            transform.SetParent(_canvasController.Canvas.transform, false);
        }

        private ICanvasController _canvasController;
    }
}