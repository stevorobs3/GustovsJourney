using UnityEngine;

namespace OnsightGames.Gustav.Utils
{
    public static class VectorUtils
    {
        public static Vector2 SetX(this Vector2 vector2, float x)
        {
            return new Vector2(x, vector2.y);
        }

        public static Vector2 SetY(this Vector2 vector2, float y)
        {
            return new Vector2(vector2.x, y);
        }

        public static Vector3 SetX(this Vector3 vector3, float x)
        {
            return new Vector3(x, vector3.y, vector3.z);
        }

        public static Vector3 SetY(this Vector3 vector3, float y)
        {
            return new Vector3(vector3.x, y, vector3.z);
        }

        public static Vector3 SetZ(this Vector3 vector3, float z)
        {
            return new Vector3(vector3.x, vector3.y, z);
        }
    }
}