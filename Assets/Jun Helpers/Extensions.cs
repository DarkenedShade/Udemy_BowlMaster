using UnityEngine;
using System.Collections.Generic;

public static class Extensions {

    public static List<T> GetComponentListInChildren<T>(this GameObject gameObj) where T : class
    {
        T[] objTArr = gameObj.GetComponentsInChildren<T>();
        List<T> list = new List<T>();

        foreach (T t in objTArr)
        {
            list.Add(t);
        }
        return list;
    }

    //public I GetInterfaceComponent<I>() where I : class
    //{
    //    return GetComponent(typeof(I)) as I;
    //}

    //public static List<I> FindObjectsOfInterface<I>() where I : class
    //{
    //    MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
    //    List<I> list = new List<I>();

    //    foreach (MonoBehaviour behaviour in monoBehaviours)
    //    {
    //        I component = behaviour.GetComponent(typeof(I)) as I;

    //        if (component != null)
    //        {
    //            list.Add(component);
    //        }
    //    }

    //    return list;
    //}
}
