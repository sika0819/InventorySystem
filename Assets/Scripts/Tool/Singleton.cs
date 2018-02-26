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
public class SingletonProvider<T> where T : class, new()
{
    private SingletonProvider()
    {
    }

    private static T _instance;
    // 用于lock块的对象
    private static readonly object _synclock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_synclock)
                {
                    if (_instance == null)
                    {
                        // 若T class具有私有构造函数,那么则无法使用SingletonProvider<T>来实例化new T();
                        _instance = new T();
                        //测试用，如果T类型创建了实例，则输出它的类型名称
                        Debug.Log("创建了单例对象" + typeof(T).Name);
                    }
                }
            }
            return _instance;
        }
        set { _instance = value; }
    }
}
