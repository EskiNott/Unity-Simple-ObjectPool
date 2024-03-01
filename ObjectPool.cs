using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an object pool that manages GameObject instances.
/// </summary>
public class ObjectPool
{
    private readonly GameObject prefab;
    private readonly List<GameObject> pool = new();

    /// <summary>
    /// Event invoked when an object is obtained from the pool.
    /// </summary>
    public event Action ObjectGet;

    /// <summary>
    /// Event invoked when a new object is created and added to the pool.
    /// </summary>
    public event Action ObjectCreat;

    /// <summary>
    /// Event invoked when an object is returned to the pool.
    /// </summary>
    public event Action ObjectReturn;

    /// <summary>
    /// Initializes a new instance of the ObjectPool class with the specified prefab and initial pool size.
    /// </summary>
    /// <param name="prefab">The prefab used to create objects in the pool.</param>
    /// <param name="initialPoolSize">The initial size of the pool.</param>
    public ObjectPool(GameObject prefab, int initialPoolSize)
    {
        this.prefab = prefab;
        PopulatePool(initialPoolSize);
    }

    /// <summary>
    /// Populates the pool with a specified number of objects.
    /// </summary>
    /// <param name="initialPoolSize">The initial size of the pool.</param>
    private void PopulatePool(int initialPoolSize)
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateObject();
        }
    }

    /// <summary>
    /// Creates a new object and adds it to the pool.
    /// </summary>
    /// <returns>The newly created object.</returns>
    private GameObject CreateObject()
    {
        GameObject obj = UnityEngine.Object.Instantiate(prefab);
        pool.Add(obj);
        ObjectCreat?.Invoke();
        return obj;
    }

    /// <summary>
    /// Retrieves an object from the pool.
    /// </summary>
    /// <returns>The object retrieved from the pool.</returns>
    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!pool.Contains(obj))
            {
                pool.Add(obj);
            }
            ObjectGet?.Invoke();
            return obj;
        }

        GameObject newObj = CreateObject();
        ObjectGet?.Invoke();
        return newObj;
    }

    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="obj">The object to be returned to the pool.</param>
    public void Return(GameObject obj)
    {
        if (!pool.Contains(obj))
        {
            pool.Add(obj);
        }
        ObjectReturn?.Invoke();
    }
}
