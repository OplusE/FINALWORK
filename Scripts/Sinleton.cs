using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 单例模式管理类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Sinleton<T>:MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get { return Sinleton<T>.instance; }
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}