﻿using UnityEngine;

namespace Suhdo
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

                return _instance;
            }
        }

        public static bool IsActive
        {
            get { return _instance != null; }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnAwake()
        {
        }
    }
}