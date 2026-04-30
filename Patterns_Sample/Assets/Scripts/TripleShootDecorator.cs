using UnityEngine;
using System.Collections;

public class TripleShootDecorator : ShootDecorator
{
    private MonoBehaviour coroutineRunner;

    public TripleShootDecorator(IShoot shoot, MonoBehaviour runner) : base(shoot)
    {
        coroutineRunner = runner;
    }

    public override void Shoot()
    {
        coroutineRunner.StartCoroutine(ShootTriple());
    }

    private IEnumerator ShootTriple()
    {
        for (int i = 0; i < 3; i++)
        {
            wrappee.Shoot();
            yield return new WaitForSeconds(0.2f); 
        }
    }
}