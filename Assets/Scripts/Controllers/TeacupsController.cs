using OnsightGames.Gustav.GameObjects;
using Zenject;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OnsightGames.Gustav.Controllers
{
    public class TeacupsController : ITeacupsController
    {
        public TeacupsController(TeacupGameObject.Pool teacupPool)
        {
            _teacupPool = teacupPool;
        }

        [Inject]
        public IEnumerator Initialize()
        {
            yield return SpawnTeacups();
        }

        private IEnumerator SpawnTeacups()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(5f);
                SpawnTeacup(i);
            }
        }

        private void SpawnTeacup(int num)
        {
            var teacup = _teacupPool.Spawn(new Vector3(num, 0, 0));
            _teacups.Add(teacup);
        }


        private readonly List<TeacupGameObject> _teacups = new List<TeacupGameObject>();
        private TeacupGameObject.Pool _teacupPool;
    }
}