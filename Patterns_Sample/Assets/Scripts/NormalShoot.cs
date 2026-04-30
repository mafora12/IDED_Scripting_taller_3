public class NormalShoot : ShootDecorator
{
    public NormalShoot(IShoot shoot) : base(shoot) { }

    public override void Shoot()
    {
        base.Shoot(); 
    }
}