# Unity Simple ObjectPool

Unity Simple ObjectPool is a lightweight object pooling system for Unity, designed to efficiently manage and reuse GameObjects in your projects.

## Features

- Efficient object pooling: Reuse GameObjects instead of instantiating and destroying them repeatedly.
- Easy integration: Simply attach the provided ObjectPool script to your GameObject prefabs to start pooling.
- Adjustable pool size: Set initial pool size and minimum amount to enlarge the pool as needed.
- Events support: Subscribe to events for object creation, retrieval, and return.

## Installation

1. Clone or download the repository.
2. Import the ObjectPool.cs script into your Unity project.
3. Attach the ObjectPool script to your GameObject prefabs.
4. Configure initial pool size and other parameters as needed.

## Usage

1. Attach the ObjectPool script to your GameObject prefabs that you want to pool.
2. Configure initial pool size and other parameters through the Unity Inspector.
3. Use the `Get()` method to retrieve objects from the pool.
4. Use the `Return()` method to return objects to the pool when no longer needed.

## Example

```csharp
// Instantiate an object pool
ObjectPool objectPool = new ObjectPool(prefab, initialPoolSize);

// Retrieve an object from the pool
GameObject obj = objectPool.Get();

// Do something with the object

// Return the object to the pool
objectPool.Return(obj);
```

## License

This project is licensed under the GNU General Public License v3.0. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.