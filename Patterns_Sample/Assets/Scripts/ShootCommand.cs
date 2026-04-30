using UnityEngine;

public class ShootCommand : MonoBehaviour, ICommand, IShoot
{
    #region Bullet

    [Header("Bullet")]
    [SerializeField]
    private Rigidbody bullet;

    [SerializeField]
    private float bulletSpeed = 3F;

    #endregion Bullet

    private Transform BulletSpawnPoint => Player.Instance.BulletSpawnPoint;

    private bool CanShoot => BulletSpawnPoint != null && bullet != null;

    public void Execute()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (CanShoot)
        {
            Bullet b = Pool.Instance.GetBullet();
            b.transform.position = BulletSpawnPoint.position;
            b.transform.rotation = BulletSpawnPoint.rotation;
            b.Rigidbody.AddForce(transform.up * bulletSpeed, ForceMode.Impulse);
        }
    }
}