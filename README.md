# Unity Simple ObjectPool

Unity Simple ObjectPool is a lightweight object pooling system for Unity projects. Object pooling is a programming pattern used to manage and reuse game objects efficiently, particularly useful for managing frequently instantiated and destroyed objects such as bullets, enemies, and particles.

## Features

- **Efficient Object Management**: Reduce memory overhead and improve performance by reusing game objects instead of instantiating and destroying them frequently.
- **Easy Integration**: Simple to use and integrate into any Unity project.
- **Event System**: Provides events for tracking object retrieval, creation, and return to the pool.
- **Customizable**: Easily customizable to suit specific project requirements.

## Installation

To use the Unity Simple ObjectPool in your Unity project, simply download or clone the repository and copy the `ObjectPool.cs` script into your project's Assets folder.

## Usage

1. **Create Prefab**: Create a prefab of the GameObject you want to pool in your Unity project.
2. **Instantiate ObjectPool**: Create an instance of the `ObjectPool` class by passing the prefab and initial pool size to the constructor.
3. **Get Object**: Use the `Get()` method to retrieve an object from the pool. If the pool is empty, a new object will be instantiated.
4. **Return Object**: Use the `Return()` method to return an object to the pool when it is no longer needed.

```csharp
// Example usage:
using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject prefab;
    private ObjectPool objectPool;

    void Start()
    {
        objectPool = new ObjectPool(prefab, 10);
    }

    void Update()
    {
        // Get an object from the pool
        GameObject obj = objectPool.Get();

        // Use the object...

        // Return the object to the pool when no longer needed
        objectPool.Return(obj);
    }
}
```

## Contributing

Contributions to Unity Simple ObjectPool are welcome! If you have any suggestions, bug reports, or feature requests, please create an issue or submit a pull request on GitHub.