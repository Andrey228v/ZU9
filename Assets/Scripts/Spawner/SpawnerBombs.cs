using UnityEngine;

namespace Assets.Scripts.Spawner
{
    [RequireComponent(typeof(ISpawnerType), typeof(ObjectPoolFigure<Bomb>))]
    public class SpawnerBombs : Spawner<Bomb>
    {
    }
}
