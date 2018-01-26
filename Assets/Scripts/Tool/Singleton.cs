using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> :MonoBehaviour where T : MonoBehaviour {
    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null)
                _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null) {
                throw new Exception("场景中需要挂载实例！"+typeof(T));
            }
            return _instance;
        }
    }

}
