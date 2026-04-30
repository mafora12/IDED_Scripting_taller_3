using UnityEngine;

public class TargetPool : AbstractPool<Target>
{
    [SerializeField] private Target prefab;

    public override Target Get()
    {
        if (pool.Count == 0) Add();

        Target t = pool[0];
        pool.RemoveAt(0);

        t.transform.SetParent(null);
        t.transform.localScale = Vector3.one;

        t.SetPool(this); 

        t.gameObject.SetActive(true);
        return t;
    }

    public override void Return(Target obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Add(obj);
    }

    private void Add()
    {
        Target t = TargetFactory.Instance.CreateInstance();
        t.transform.SetParent(transform);
        t.SetPool(this);
        t.gameObject.SetActive(false);
        pool.Add(t);
    }
}