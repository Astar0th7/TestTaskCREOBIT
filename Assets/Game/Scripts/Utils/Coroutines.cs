using UnityEngine;

namespace Game.Scripts.Utils
{
    public class Coroutines : MonoBehaviour
    {
        private static Coroutines _instance;

        public static Coroutines Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                
                return _instance;
            }
        }
    }
}