using UnityEngine;

public class TargetFacade : MonoBehaviour
{
    public static TargetFacade Instance;
    [SerializeField] private TargetPool[] pools;

    private void Awake() => Instance = this;

    public Target GetTarget()
    {
        if (pools == null || pools.Length == 0) return null;

        int index = Random.Range(0, pools.Length);
        return pools[index].Get();
    }
}