using UnityEngine;

public class NormalShoot : IShoot
{
    public void Shoot()
    {
        ShootCommand shoot = GameObject.FindObjectOfType<ShootCommand>();
        shoot?.Execute();
    }
}