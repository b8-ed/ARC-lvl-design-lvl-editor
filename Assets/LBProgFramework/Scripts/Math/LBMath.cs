///Made by Luis Bernardo Bazan Bravo
///Github-user: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LBProgramming
{
    public static class LBMath
    {
        public const float PI = Mathf.PI;
        public const float PI2 = Mathf.PI * 2f;
        public const float TAU = Mathf.PI * 2;

        public static float Sign(float _value, float _deadZone = 0f)
        {
            return _value > _deadZone ? 1f : (_value < -_deadZone ? -1f : 0f);
        }

        /// <summary>
        /// Angle to Vector2
        /// </summary>
        /// <param name="_angle"></param>
        /// <returns>Direction of Angle</returns>
        public static Vector2 AngleToV2(float _angle)
        {
            _angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

        /// <summary>
        /// Angle in RAD to Vector2
        /// </summary>
        /// <param name="_angle">Angle in RAD</param>
        /// <returns>Direction of Angle</returns>
        public static Vector2 AngleRadToV2(float _angle)
        {
            return new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));
        }

    }
}
