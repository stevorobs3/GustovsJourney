using OnsightGames.Gustav.Controllers;
using OnsightGames.Gustav.Models;
using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.ViewControllers
{
    public class GustavInput : MonoBehaviour
    {
        [Inject]
        public void Create(IGustavController gustavController)
        {
            _gustavController = gustavController;
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _gustavController.Move(GustavDirection.Left, Time.deltaTime, isRunning:false);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _gustavController.Move(GustavDirection.Right, Time.deltaTime, isRunning:false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _gustavController.Fly();
            }
        }

        private IGustavController _gustavController;
    }
}