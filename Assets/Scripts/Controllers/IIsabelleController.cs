
namespace OnsightGames.Gustov.Controllers
{
    public delegate void CollectedHandler();

    public interface IIsabelleController
    {
        event CollectedHandler Collected;
    }
}