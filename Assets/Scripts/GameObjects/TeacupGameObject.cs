using UnityEngine;
using Zenject;

namespace OnsightGames.Gustav.GameObjects
{
    public class TeacupGameObject : MonoBehaviour
    {
        public void Reset(Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
        }

        public class Pool : MemoryPool<Vector3, TeacupGameObject>
        {
            protected override void Reinitialize(Vector3 spawnPosition, TeacupGameObject teacup)
            {
                teacup.Reset(spawnPosition);
            }
        }
    }
}