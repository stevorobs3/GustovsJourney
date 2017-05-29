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

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _gustavController.Move(GustavDirection.Left, Time.deltaTime, isRunning);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _gustavController.Move(GustavDirection.Right, Time.deltaTime, isRunning);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                _gustavController.Jump();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _gustavController.PourTea();
            }

        }

        private IGustavController _gustavController;
    }
}