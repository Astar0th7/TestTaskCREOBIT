using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.GameRoot.Services.ServiceLocator
{
    public class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> _services = new();
        private static ServiceLocator _instance;

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("[SERVICE_LOCATOR]").AddComponent<ServiceLocator>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                
                return _instance;
            }
        }

        public T RegisterSingle<T>(T service)
        {
            Type type = typeof(T);
            if (_services.ContainsKey(type))
                throw new ArgumentException($"Service with this type '{type}' is already registered");

            _services.Add(type, service);
            return (T) _services[type];
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);
            if (_services.ContainsKey(type) == false)
                throw new ArgumentException($"Service with this type '{type}' is not registered");

            return (T) _services[type];
        }    
    }
}