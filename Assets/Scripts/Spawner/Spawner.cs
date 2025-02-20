using Assets.Scripts;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : Component, ISpawnObject<T>
{
    public ISpawnerType SpawnerType { get; private set; }
    public ObjectPoolFigure<T> PoolFigure { get; private set; }

    private void Awake()
    {
        SpawnerType = GetComponent<ISpawnerType>();
        PoolFigure = GetComponent<ObjectPoolFigure<T>>();
    }
}
