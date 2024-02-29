using System;
using System.Collections.Generic;

/// <summary>
/// Represents an object pool that manages objects of type T.
/// </summary>
/// <typeparam name="T">The type of objects managed by the pool.</typeparam>
public class ObjectPool<T>
{
    private readonly T prefab;
    private readonly List<T> pool = new();

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
    public ObjectPool(T prefab, int initialPoolSize)
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
    private T CreateObject()
    {
        T obj = prefab;
        pool.Add(obj);
        ObjectCreat?.Invoke();
        return obj;
    }

    /// <summary>
    /// Retrieves an object from the pool.
    /// </summary>
    /// <returns>The object retrieved from the pool.</returns>
    public T Get()
    {
        foreach (T obj in pool)
        {
            if (!pool.Contains(obj))
            {
                pool.Add(obj);
            }
            ObjectGet?.Invoke();
            return obj;
        }

        T newObj = CreateObject();
        ObjectGet?.Invoke();
        return newObj;
    }

    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="obj">The object to be returned to the pool.</param>
    public void Return(T obj)
    {
        if (!pool.Contains(obj))
        {
            pool.Add(obj);
        }
        ObjectReturn?.Invoke();
    }
}
