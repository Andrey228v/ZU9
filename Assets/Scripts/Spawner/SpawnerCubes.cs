using UnityEngine;

namespace Assets.Scripts.Spawner
{

    [RequireComponent(typeof(ISpawnerType), typeof(ObjectPoolFigure<Cube>))]
    public class SpawnerCubes : Spawner<Cube>
    {
    }
}
