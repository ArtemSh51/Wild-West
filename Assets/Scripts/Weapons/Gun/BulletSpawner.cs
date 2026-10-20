using UnityEngine;

public class BulletSpawner : Pool<Bullet>
{
    public Bullet GetBullet()
    {
        return Get();
    }

    protected override void Subscribe(Bullet bullet)
    {
        bullet.LifetimeExpired += ReturnBullet;
    }

    protected override void Unsubscribe(Bullet bullet)
    {
        bullet.LifetimeExpired -= ReturnBullet;
    }

    protected override void ResetState(Bullet bullet)
    {
        if (bullet.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void ReturnBullet(Bullet bullet)
    {
        Release(bullet);
    }
}