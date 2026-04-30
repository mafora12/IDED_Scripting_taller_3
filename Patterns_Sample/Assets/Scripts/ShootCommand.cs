using UnityEngine;

public void Execute()
{
    Shoot();
}

public void Shoot()
{
    if (CanShoot)
    {
        Bullet bullet = Pool.Instance.GetBullet();
        bullet.transform.position = BulletSpawnPoint.position;
        bullet.transform.rotation = BulletSpawnPoint.rotation;
        bullet.Rigidbody.AddForce(transform.up * bulletSpeed, ForceMode.Impulse);
    }
}