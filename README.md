# Unity Simple Object Pool

## Introduction

Unity Simple Object Pool is a lightweight object pooling utility for Unity game developers. Object pooling is a technique commonly used to optimize memory usage and performance in games by recycling objects instead of instantiating and destroying them repeatedly. This utility provides a simple and efficient way to manage objects of any type within your Unity projects.

## Features

- **Generic Object Pooling:** Easily manage objects of any type within your Unity projects.
- **Efficient Memory Management:** Reduces memory allocation and performance overhead by reusing objects.
- **Event System:** Event-based callbacks for object creation, retrieval, and return, allowing for easy integration with other systems.
- **Customizable Pool Size:** Set the initial size of the object pool to suit your project's requirements.

## Installation

To use Unity Simple Object Pool in your Unity project, simply download the `UnitySimpleObjectPool.cs` script and add it to your project's Assets folder.

## Usage

1. Create a prefab of the object you want to pool.
2. Instantiate an instance of the `ObjectPool<T>` class, specifying the prefab and initial pool size.
3. Use the `Get()` method to retrieve objects from the pool, and the `Return(T obj)` method to return objects to the pool when they are no longer needed.

```csharp
// Example usage
ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>(prefab, initialPoolSize);
GameObject obj = objectPool.Get();
// Use the object...
objectPool.Return(obj);
```

## Example

```csharp
// Example usage with GameObjects
using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 10;
    private ObjectPool<GameObject> objectPool;

    void Start()
    {
        objectPool = new ObjectPool<GameObject>(prefab, initialPoolSize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objectPool.Get();
            // Use the object...
        }
    }
}
```

## Contributing

Contributions are welcome! If you have any ideas for improvements or new features, feel free to open an issue or submit a pull request.