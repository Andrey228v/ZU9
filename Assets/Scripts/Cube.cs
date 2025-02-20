using Assets.Scripts;
using System;
using UnityEngine;

public class Cube : MonoBehaviour, ISpawnObject<Cube>
{
    [SerializeField] private CubeView _cubeView;
    [SerializeField] private CubeDestroyer _cubeDestroyer;
    
    public event Action<Cube> DestroedSpawnObject;

    private void OnEnable()
    {
        _cubeView.CollisedWithGround += _cubeDestroyer.StartDestroy;
        _cubeDestroyer.Destroed += _cubeView.SetDefaultParametrs;
        _cubeDestroyer.Destroed += Despawn;

    }

    private void OnDisable()
    {
        _cubeView.CollisedWithGround -= _cubeDestroyer.StartDestroy;
        _cubeDestroyer.Destroed -= _cubeView.SetDefaultParametrs;
        _cubeDestroyer.Destroed -= Despawn;
    }

    public void Despawn()
    {
        DestroedSpawnObject?.Invoke(this);
    }
}
