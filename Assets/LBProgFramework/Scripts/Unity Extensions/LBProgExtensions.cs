///Made by Luis Bernardo Bazan Bravo
///Github-user: luisquid11

using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LBProgramming
{
    public static class LBProgExtensions 
    {
        #region string
        public static string UppercaseFirstLetter(this string _val)
        {
            if(_val.Length > 0)
            {
                char[] array = _val.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }

            return _val;
        }

        public static int toInt(this string input)
        {
            int result;
            bool valid = int.TryParse(input, out result);
            if (valid)
                return result;
            else
                return 0;
        }

        public static float toFloat(this string input)
        {
            float result;
            bool valid = float.TryParse(input, out result);
            if (valid)
                return result;
            else
                return 0.0f;
        }

        public static double toDouble(this string input)
        {
            double result;
            bool valid = double.TryParse(input, out result);
            if (valid)
                return result;
            else
                return 0.0;
        }

        public static long toLong(this string input)
        {
            long result;
            bool valid = long.TryParse(input, out result);
            if (valid)
                return result;
            else
                return 0;
        }

        public static bool isNumber(this string input)
        {
            Match match = Regex.Match(input, @"^[0-9]+$", RegexOptions.IgnoreCase);
            return match.Success;
        }
        #endregion

        #region Transform
        public static void ResetTransform(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void ResetScale(this Transform transform)
        {
            transform.localScale = Vector3.one;
        }
        #endregion

        #region List<T>
        public static bool Empty<T>(this List<T> list)
        {
            return list.Count == 0;
        }

        public static void Push<T>(this List<T> list, T item)
        {
            list.Insert(0, item);
        }

        public static T PopAt<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static T Pop<T>(this List<T> list)
        {
            return list.PopAt(list.Count);
        }

        public static void AddAndExecute<T>(this List<T> list, T elementToAdd, Func<int>methodToExecute)
        {
            list.Add(elementToAdd);
            methodToExecute();
        }

        public static void RemoveAndExecute<T>(this List<T> list, T elementToRemove, Func<T,int>methodToExecute)
        {
            list.Remove(elementToRemove);
            methodToExecute(elementToRemove);
        }

        #endregion 

        #region List<float>
        public static int BinarySearchForApproximateIndex(this List<float> _list, float _item)
        {
            int left = 0;
            int right = _list.Count - 1;
            int index = 0;

            if (_list[index] == _item)
                return index;

            if (_item > _list[right])
                return right;

            while (right - left > 1)
            {

                int middle = (int)Mathf.Floor(((float)right - (float)left) / 2.0f);
                middle += left;
                float targetIndex = _list[middle];

                if (targetIndex == _item)
                {
                    index = middle + 1;
                    return index;
                }

                else if (_item > targetIndex)
                    left = middle;
                else
                    right = middle;
            }

            index = right;

            if (right - left == 0)
                index++;

            return index;
        }
        #endregion

        #region Compontents
        public static T GetRequiredComponent<T>(this GameObject obj) where T : MonoBehaviour
        {
            T component = obj.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError("Expected to find component of type "
                   + typeof(T) + " but found none", obj);
            }

            return component;
        }
        #endregion

        #region GameObject
        public static GameObject FindRoot(this GameObject childObject)
        {
            return childObject.transform.root.gameObject;
        }

        /// <summary>
        /// Try to get a component, if the gameobject dont have that component, add it
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="_gameObject">Self GameObject</param>
        /// <param name="_component">Component</param>
        /// <returns>the component or new component</returns>
        public static T GetOrAddComponent<T>(this GameObject _gameObject) where T : Component
        {
            T component = _gameObject.GetComponent<T>();
            if (component == null)
            {
                component = _gameObject.AddComponent<T>();
            }
            return component;
        }
        #endregion

        #region Vector
        public static Vector3 AddX(this Vector3 vec3, float _x)
        {
            return new Vector3(vec3.x + _x, vec3.y, vec3.z);
        }

        public static Vector3 AddY(this Vector3 vec3, float _y)
        {
            return new Vector3(vec3.x, vec3.y + _y, vec3.z);
        }

        public static Vector3 AddZ(this Vector3 vec3, float _z)
        {
            return new Vector3(vec3.x, vec3.y, vec3.z + _z);
        }

        public static Vector3 AddV3(this Vector3 vec3, Vector3 _right)
        {
            return new Vector3(vec3.x + _right.x, vec3.y + _right.y, vec3.z + _right.z);
        }

        public static Vector3 SubstractV3(this Vector3 vec3, Vector3 _right)
        {
            return new Vector3(vec3.x - _right.x, vec3.y - _right.y, vec3.z - _right.z);
        }

        public static bool BiggerXThanV3(this Vector3 vec3, Vector3 _right)
        {
            return vec3.x > _right.x;
        }

        public static bool BiggerYThanV3(this Vector3 vec3, Vector3 _right)
        {
            return vec3.y > _right.y;
        }

        public static bool BiggerZThanV3(this Vector3 vec3, Vector3 _right)
        {
            return vec3.z > _right.z;
        }

        public static Vector3 ConvertV2ToV3(this Vector2 vec2, float zValue)
        {
            return new Vector3(vec2.x, vec2.y, zValue);
        }

        public static float DistanceBetweenVector3(this Vector3 vec3, Vector3 _right)
        {
            return (vec3.x - _right.x) + (vec3.y - _right.y) + (vec3.z - _right.z);
        }
        #endregion

        #region Texture2D

        /// <summary>
        /// Merge two png sprites together. They must be the same length for it to work.
        /// </summary>
        /// <param name="tex2D"></param>
        /// <param name="_right"></param>
        /// <returns></returns>
        public static Texture2D MergeSprite(this Texture2D tex2D, Texture2D _right)
        {
            Color[] sourceImg = tex2D.GetPixels();
            Color[] tomergeImg = _right.GetPixels();
            Color[] newImg = new Color[sourceImg.Length];

            int width = tex2D.width;
            int height = tex2D.height;

            for(int i = 0; i < height * width; i++)
            {
                if (sourceImg[i].a > 0 && !(tomergeImg[i].a > 0))
                    newImg[i] = sourceImg[i];
                else if (tomergeImg[i].a > 0 && !(sourceImg[i].a > 0))
                    newImg[i] = tomergeImg[i];
                else
                    newImg[i] = sourceImg[i];
            }

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(newImg);
            result.Apply();
            return result;
        }
        #endregion
    }
}
