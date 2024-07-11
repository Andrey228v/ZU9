using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolFigure: MonoBehaviour
{
    [SerializeField] private SpawnerObject _typePrefab;

    private int _poolCapacity = 10;
    private int _poolSize = 30;

    public ObjectPool<SpawnerObject> Pool {get; private set;}

    private void Awake()
    {
        Pool = new ObjectPool<SpawnerObject>(OnCreateFigure, OnTakeFromPool, OnRelease, OnDestroyFigure, false, _poolCapacity, _poolSize);
    }

    private SpawnerObject OnCreateFigure()
    {
        return Instantiate(_typePrefab);
    }

    private void OnTakeFromPool(SpawnerObject figure)
    {
        figure.gameObject.SetActive(true);
    }

    private void OnRelease(SpawnerObject figure)
    {
        figure.gameObject.SetActive(false);
    }

    private void OnDestroyFigure(SpawnerObject figure)
    {
        Destroy(figure);
    }
}
