using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxSize;

    private ObjectPool<T> _pool;

    protected ObjectPool<T> PoolObject => _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
        (
            createFunc: () => Instantiate(_prefab),
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
        );

        OnAwake();
    }

    protected T Get()
    {
        return _pool.Get();
    }

    protected void Release(T obj)
    {
        _pool.Release(obj);
    }

    private void OnGet(T obj)
    {
        Subscribe(obj);
        obj.gameObject.SetActive(true);
        PrepareBefore(obj);
    }

    private void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        Unsubscribe(obj);
        ResetTransform(obj);
        ResetState(obj);
    }

    private void ResetTransform(T obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
    }

    protected abstract void Subscribe(T obj);
    protected abstract void Unsubscribe(T obj);

    protected virtual void PrepareBefore(T obj) { }
    protected virtual void ResetState(T obj) { }
    protected virtual void OnAwake() { }
}