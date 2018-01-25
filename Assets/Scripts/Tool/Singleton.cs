using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour {
    private static Singleton<T> _instance;
    public static Singleton<T> Instance {
        get {
            return _instance;
        }
    }
    // Use this for initialization
    void Awake () {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
