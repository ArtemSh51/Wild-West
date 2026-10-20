using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _defaultCountsOfBullets;
    [SerializeField] private int _maxSize;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>
        (
            createFunc: () => Instantiate(_bulletPrefab),
            actionOnGet: (bullet) => PrepareBulletBeforeUseBullet(bullet),
            actionOnRelease: (bullet) => PrepareBulletAfterUse(bullet),
            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCountsOfBullets,
            maxSize: _maxSize
        );
    }

    public Bullet GetBullet()
    {
        Bullet newBullet = _bulletPool.Get();

        return newBullet;
    }

    private void PrepareBulletBeforeUseBullet(Bullet bullet)
    {
        bullet.LifetimeExpired += ReturnBullet;
        bullet.gameObject.SetActive(true);
    }

    private void PrepareBulletAfterUse(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.LifetimeExpired -= ReturnBullet;
        bullet.transform.position = Vector3.zero;
        bullet.transform.rotation = Quaternion.identity;

        if (bullet.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void ReturnBullet(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
