using OnsightGames.Gustov.Controllers;
using OnsightGames.Gustov.Models;
using UnityEngine;
using Zenject;

namespace OnsightGames.Gustov.ViewControllers
{
    public class GustovInput : MonoBehaviour
    {
        [Inject]
        public void Create(IGustovController gustovController)
        {
            _gustovController = gustovController;
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _gustovController.Move(GustovDirection.Left, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _gustovController.Move(GustovDirection.Right, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                _gustovController.Jump();
            }
        }

        private IGustovController _gustovController;
    }
}