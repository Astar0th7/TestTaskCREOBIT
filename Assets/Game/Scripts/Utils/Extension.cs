using UnityEngine;

namespace Game.Scripts.Utils
{
    public static class Extension
    {
        public static string ToSerialized(this object obj) => 
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
    }
}