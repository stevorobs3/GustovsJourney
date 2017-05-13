using OnsightGames.Gustov.Models;

namespace OnsightGames.Gustov.Controllers
{
    public interface IGustovController
    {
        void Move(GustovDirection direction, float deltaTime);
    }
}