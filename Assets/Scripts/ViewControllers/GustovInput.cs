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

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _gustovController.Move(GustovDirection.Left, Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _gustovController.Move(GustovDirection.Right, Time.deltaTime);
            }
        }

        private IGustovController _gustovController;
    }
}