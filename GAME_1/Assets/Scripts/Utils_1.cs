using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Utils_1
{
    public static class Common2
    {
        /*
        public static float maxSpeed = 73f;
        public static float minSpeed = 55f;
        */
        public static Vector3 GetRandomirPoint(float min_, float max_)
        {
            float x = UnityEngine.Random.Range(min_, max_);
            return new Vector3(x, 0f, 0f); // y и z компоненты равны 0
        }
        public static float RandomFloatBetween(float min, float max)
        {
            System.Random random = new System.Random();
            double range = max - min;
            double sample = random.NextDouble();
            double scaled = (sample * range) + min;
            return (float)scaled;
        }
    }
}
