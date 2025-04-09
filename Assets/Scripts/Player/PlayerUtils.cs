using UnityEngine;

namespace Player
{
    public static class PlayerUtils
    {
        public static Vector3 GetRelativeDirection(Vector3 direction, Transform transform)
        {
            var dir = direction.x * transform.right + direction.z * transform.forward;
            return dir.normalized;
        }
    }
}