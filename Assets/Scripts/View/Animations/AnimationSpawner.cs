using UnityEngine;
using UnityEngine.Pool;

public abstract class AnimationSpawner<T> : MonoBehaviour where T : SpawnableAnimation
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    public virtual T Get(Vector3 position)
    {
        T obj = _pool.Get();
        obj.transform.position = position;
        return obj;
    }

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab, transform),
            actionOnGet: (obj) => OnActionGet(obj),
            actionOnRelease: (obj) => OnActionRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true
        );
    }

    protected virtual void OnActionGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnActionRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected void Release(T obj) 
    {
        _pool.Release(obj);
    }
}
