using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Min(0.1f)][SerializeField] private float _timeSpawn;
    [SerializeField] private ObjectPoolFigure _poolFigure;

    private bool _isSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isSpawn)
        {
            SpawnerObject figure = _poolFigure.Pool.Get();

            Vector3 position = GetSpawnPosition();
            figure.transform.position = position;
            figure.SetSpawner(this);

            yield return new WaitForSeconds(_timeSpawn);
        }
    }

    public void ReturnToPool(SpawnerObject spawnTypeObject)
    {
        _poolFigure.Pool.Release(spawnTypeObject);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 bounds = GetComponent<Collider>().bounds.extents;

        float x = Random.Range(-bounds.x, bounds.x);
        float y = transform.position.y;
        float z = Random.Range(-bounds.z, bounds.z);

        Vector3 position = new Vector3(x, y, z);

        return position;
    }
}
