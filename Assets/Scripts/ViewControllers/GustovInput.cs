using OnsightGames.Gustov.Controllers;
using UnityEngine;

namespace OnsightGames.Gustov.ViewControllers
{
    public class GustovInput : MonoBehaviour
    {
        public GustovInput(IGustovController gustovController)
        {
            _gustovController = gustovController;
        }

        private IGustovController _gustovController;
    }
}