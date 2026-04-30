using UnityEngine;

public class TargetPool : AbstractPool<Target>
{
    [SerializeField] private Target prefab;
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Add();
        }
    }
    public override Target Get()
    {
        if (pool.Count == 0)
        {
            Add();
        }

        Target t = pool[0];
        pool.RemoveAt(0);
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
        Target t = Instantiate(prefab, transform);
        t.SetPool(this);
        t.gameObject.SetActive(false);
        pool.Add(t);
    }
}