using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _poolCapacity = 400;
    [SerializeField] private int _poolMaxSize = 400;

    private ObjectPool<Cube> _pool;
    private int _poolCount = 0;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public Cube Get()
    {
        _poolCount++;
        Debug.Log(_poolCount);
        return _pool.Get();
    }

    public void Release(Cube obj)
    {
        _poolCount--;
        _pool.Release(obj);
    }
}
