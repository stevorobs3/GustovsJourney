using UnityEngine;

namespace OnsightGames.Gustav.Controllers
{
    public class LevelBoundary
    {
        public LevelBoundary(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;            
        }

        public readonly Vector2 Max;
        public readonly Vector2 Min;

        public override string ToString()
        {
            return "LevelBoundary(" + Min.ToString() + ", " + Max.ToString() + ")";
        }
    }
}