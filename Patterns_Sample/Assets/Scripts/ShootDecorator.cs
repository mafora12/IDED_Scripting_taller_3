public abstract class ShootDecorator : IShoot
{
    protected IShoot wrappee;

    public ShootDecorator(IShoot shoot)
    {
        wrappee = shoot;
    }

    public virtual void Shoot()
    {
        wrappee.Shoot();
    }
}