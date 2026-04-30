using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {

        Invoke(nameof(StartRepeating), 0.5f);
    }

    private void StartRepeating()
    {
        if (TargetFacade.Instance != null)
        {
            InvokeRepeating("SpawnObject", firstSpawnDelay, spawnRate);
            if (Player.Instance != null)
                Player.Instance.OnPlayerDied += StopSpawning;
        }
        else
        {
            Debug.LogError("No se encontró el TargetFacade en la escena.");
        }
    }

    private void SpawnObject()
    {
        Target target = TargetFacade.Instance.GetTarget();

        if (target != null)
        {

            spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(
                Random.Range(0.1F, 0.9F), 1.1F, Mathf.Abs(Camera.main.transform.position.z)
            ));


            target.transform.SetParent(null);

            target.transform.position = spawnPoint;
            target.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("El Facade no devolvió ningún Target. Revisa los Pools.");
        }
    }

    private void StopSpawning() => CancelInvoke();
}