using OnsightGames.Gustav.GameObjects;

namespace OnsightGames.Gustav.Controllers
{
    public class IsabelleController : IIsabelleController
    {
        public IsabelleController(IsabelleGameObject isabelle)
        {
            _isabelle = isabelle;
            isabelle.Collected += NotifyCollected;
        }

        public event CollectedHandler Collected;

        private void NotifyCollected()
        {
            if (Collected != null)
                Collected();
        }

        private IsabelleGameObject _isabelle;
    }
}