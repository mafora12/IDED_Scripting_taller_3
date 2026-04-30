using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPool<T> : MonoBehaviour where T : MonoBehaviour
{
    protected List<T> pool = new List<T>();

    public abstract T Get();
    public abstract void Return(T obj);
}