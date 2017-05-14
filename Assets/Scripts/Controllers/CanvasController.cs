using UnityEngine;

namespace OnsightGames.Gustov.Controllers
{
    public class CanvasController : ICanvasController
    {
        public CanvasController(Canvas canvas)
        {
            _canvas = canvas;
            SetupCanvas();
        }

        public Canvas Canvas
        {
            get
            {
                return _canvas;
            }
        }

        private void SetupCanvas()
        {
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        private Canvas _canvas;
    }
}