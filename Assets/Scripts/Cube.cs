using Assets.Scripts;
using System;
using UnityEngine;

public class Cube : MonoBehaviour, ISpawnObject<Cube>
{
    [field: SerializeField] public CubeDestroyer CubeDestroyer { get; private set; }
    [field: SerializeField] public GroundDetecter GroundDetecter { get; private set; }

    public event Action<Cube> DestroedSpawnObject;

    private void OnEnable()
    {
        GroundDetecter.CollisedWithGround += CubeDestroyer.StartDestroy;
        CubeDestroyer.Destroed += Despawn;
    }

    private void OnDisable()
    {
        GroundDetecter.CollisedWithGround -= CubeDestroyer.StartDestroy;
        CubeDestroyer.Destroed -= Despawn;
    }

    public void Despawn()
    {
        DestroedSpawnObject?.Invoke(this);
    }
}
