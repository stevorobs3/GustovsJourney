using OnsightGames.Gustav.GameObjects;
using OnsightGames.Gustav.Services;
using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.Controllers
{
    public class CameraController : ICameraController, IFixedTickable
    {
        public CameraController(PixelPerfectCamera camera, GustavGameObject gustav, IPlatformController platformController)
        {
            _camera = camera;
            _gustav = gustav;
            _platformController = platformController;

        }

        public void FixedTick()
        {
            var bottomLeft = _camera.Camera.ViewportToWorldPoint(Vector3.zero) + ToleranceVector;
            var topRight   = _camera.Camera.ViewportToWorldPoint(TopRight) - ToleranceVector;

            var cameraDelta = CalculateCameraDelta(bottomLeft, topRight);
            _camera.Camera.transform.position += cameraDelta;
            SnapToLevelBoundary();
        }

        private void SnapToLevelBoundary()
        {
            // Do something to ensure the camera stays with the bounds of the game
            //_platformController.LevelBoundary.min
        }

        private Vector3 CalculateCameraDelta(Vector3 bottomLeft, Vector3 topRight)
        {
            var gustavTransform = _gustav.transform.position;
            float xDelta = 0;
            if (gustavTransform.x < bottomLeft.x)
                xDelta = gustavTransform.x - bottomLeft.x;
            else if (gustavTransform.x > topRight.x)
                xDelta = gustavTransform.x - topRight.x;
            else
                xDelta = 0;

            float yDelta = 0;
            if (gustavTransform.y < bottomLeft.y)
                yDelta = gustavTransform.y - bottomLeft.y;
            else if (gustavTransform.y > topRight.y)
                yDelta = gustavTransform.y - topRight.y;
            else
                yDelta = 0;

            return new Vector3(xDelta, yDelta, 0f);

        }

        private PixelPerfectCamera _camera;
        private readonly Vector3 TopRight = new Vector3(1, 1, 0);
        private const float Tolerance = 3f;
        private readonly Vector3 ToleranceVector = new Vector3(Tolerance, Tolerance, 0);

        private GustavGameObject _gustav;
        private IPlatformController _platformController;
    }
}