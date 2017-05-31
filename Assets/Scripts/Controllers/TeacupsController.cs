using OnsightGames.Gustav.GameObjects;
using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OnsightGames.Gustav.Controllers
{
    public class TeacupsController : ITeacupsController
    {
        public TeacupsController(
            TeacupGameObject.Pool teacupPool,
            TeacupPiecesGameObject.Pool teacupPiecesPool,
            IScoreController scoreController,
            IGustavController gustavController
        )
        {
            _teacupPool       = teacupPool;
            _teacupPiecesPool = teacupPiecesPool;
            _scoreController  = scoreController;
            _gustavController = gustavController;
        }

        [Inject]
        public IEnumerator Initialize()
        {
            yield return SpawnTeacups();
        }

        private IEnumerator SpawnTeacups()
        {
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    SpawnTeacup(i);
                    yield return new WaitForSeconds(2f);
                }
            }
        }

        private void SpawnTeacup(int num)
        {
            var teacup = _teacupPool.Spawn(new Vector3(num, 0, 0));
            _teacups.Add(teacup);
            teacup.CollectedByGustav += HandleCollectedByGustav;
            teacup.CollidedWithGustav += HandleCollidedWithGustav;
            teacup.CupFilled          += HandleCupFilled;
        }

        private void HandleCollectedByGustav(TeacupGameObject teacup)
        {
            _teacupPool.Despawn(teacup);
            _scoreController.IncrementScore(50);
            teacup.CollectedByGustav -= HandleCollectedByGustav;
        }

        private void HandleCollidedWithGustav(TeacupGameObject teacup)
        {
            _gustavController.Die();
            var pieces = _teacupPiecesPool.Spawn(teacup.transform);
            pieces.Exploded += DespawnPieces;
            teacup.CollidedWithGustav -= HandleCollidedWithGustav;
        }

        private void DespawnPieces(TeacupPiecesGameObject pieces)
        {
            _teacupPiecesPool.Despawn(pieces);
            pieces.Exploded -= DespawnPieces;
        }

        private void HandleCupFilled(TeacupGameObject teacup)
        {
            Debug.Log("Congratz on filling the cup");
            teacup.CupFilled -= HandleCupFilled;
        }

        private readonly List<TeacupGameObject> _teacups = new List<TeacupGameObject>();
        private readonly TeacupGameObject.Pool _teacupPool;
        private readonly TeacupPiecesGameObject.Pool _teacupPiecesPool;
        private readonly IScoreController _scoreController;
        private readonly IGustavController _gustavController;
    }
}