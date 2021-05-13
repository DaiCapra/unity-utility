using System.Linq;
using UnityEngine;

namespace Utility.Extensions
{
    public static class MonoExtensions
    {
        public static bool Approximately(this Quaternion quaternion, Quaternion other, float acceptableThreshold)
        {
            return 1 - Mathf.Abs(Quaternion.Dot(quaternion, other)) < acceptableThreshold;
        }

        public static void ValidateComponent<TK, TV>(
            this TK mono,
            ref TV behaviour,
            bool includeSelf = true,
            bool includeInactive = true)
            where TK : MonoBehaviour
            where TV : Component
        {
            if (mono == null)
            {
                return;
            }

            if (behaviour != null)
            {
                return;
            }

            var c = mono.GetComponentsInChildren<TV>();
            if (!includeSelf)
            {
                var f = c.FirstOrDefault(t => t.transform.Equals(mono.transform));
                behaviour = f;
            }
            else
            {
                behaviour = c.FirstOrDefault();
            }
        }

        public static void Toggle(this Transform transform, bool isEnabled)
        {
            if (transform == null)
            {
                return;
            }

            Toggle(transform.gameObject, isEnabled);
        }

        public static void Toggle(this GameObject gameObject, bool isEnabled)
        {
            if (gameObject == null)
            {
                return;
            }

            if (!gameObject.activeSelf && isEnabled)
            {
                gameObject.SetActive(true);
            }
            else if (gameObject.activeSelf && !isEnabled)
            {
                gameObject.SetActive(false);
            }
        }


        public static Transform[] GetChildren(this Transform transform, bool includeInactive = true)
        {
            if (transform == null)
            {
                return new Transform[0];
            }

            return transform.GetComponentsInChildren<Transform>(includeInactive)
                .Where(t => t != null && t != transform)
                .ToArray();
        }


        public static bool HasComponent<T>(this Behaviour behaviour)
            where T : Component
        {
            return behaviour.GetComponent<T>() != null;
        }

        public static bool HasComponent<T>(this GameObject gameObject)
            where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }

        public static T EnsureComponent<T>(this GameObject behaviour) where T : Component
        {
            if (behaviour == null)
            {
                return null;
            }

            if (behaviour.HasComponent<T>())
            {
                return behaviour.GetComponent<T>();
            }

            var c = behaviour.AddComponent<T>();
            return c;
        }

        public static Vector3Int ToVector3Int(this Vector3 vector)
        {
            var v = new Vector3Int((int) vector.x, (int) vector.y, (int) vector.z);
            return v;
        }
    }
}