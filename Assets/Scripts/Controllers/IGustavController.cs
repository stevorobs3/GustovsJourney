using OnsightGames.Gustav.Models;

namespace OnsightGames.Gustav.Controllers
{
    public interface IGustavController
    {
        void Move(GustavDirection direction, float deltaTime, bool isRunning);
        void Jump();
        void PourTea();
        void Die();
    }
}