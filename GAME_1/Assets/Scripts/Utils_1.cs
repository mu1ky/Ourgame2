using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utils_1
{
    public static class Common2
    {
        public static float maxSpeed = 73f;
        public static float minSpeed = 55f;
        public static Vector3 GetRandomirPoint()
        {
            float x = UnityEngine.Random.Range(minSpeed, maxSpeed);
            return new Vector3(x, 0f, 0f); // y и z компоненты равны 0
        }
    }
}
