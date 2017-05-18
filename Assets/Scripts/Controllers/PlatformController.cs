using OnsightGames.Gustav.GameObjects;
using OnsightGames.Gustav.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace OnsightGames.Gustav.Controllers
{
    public class PlatformController : IPlatformController
    {
        public PlatformController(List<PlatformGameObject> platforms)
        {
            _platforms = platforms;
            _levelBoundary = CalculateLevelBoundary(platforms);
            Debug.Log("LevelBoundary = " + _levelBoundary.ToString());
        }

        public LevelBoundary LevelBoundary
        {
            get
            {
                return _levelBoundary;
            }
        }

        protected static LevelBoundary CalculateLevelBoundary(List<PlatformGameObject> platforms)
        {
            Vector2 min = platforms[0].Collider.bounds.min;
            Vector2 max = platforms[0].Collider.bounds.max;
            Debug.Log("platorm 0 = " + platforms[0].Collider.bounds.min + "," + platforms[0].Collider.bounds.max);
            for (int i = 1; i < platforms.Count; i++)
            {
                var platform = platforms[i];
                Debug.Log("platorm " + i + " = " + platform.Collider.bounds.min + "," + platform.Collider.bounds.max);
                if (platform.Collider.bounds.min.x < min.x)
                    min = min.SetX(platform.Collider.bounds.min.x);
                if (platform.Collider.bounds.min.y < min.y)
                    min = min.SetY(platform.Collider.bounds.min.y);
                if (platform.Collider.bounds.max.x > max.x)
                    max = max.SetX(platform.Collider.bounds.max.x);
                if (platform.Collider.bounds.max.y > max.y)
                    max = max.SetY(platform.Collider.bounds.max.y);
            }
            return new LevelBoundary(min, max);
        }

        private List<PlatformGameObject> _platforms;
        private LevelBoundary _levelBoundary;

    }
}