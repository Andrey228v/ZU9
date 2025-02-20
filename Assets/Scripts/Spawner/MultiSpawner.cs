using UnityEngine;

namespace Assets.Scripts.Spawner
{
    public class MultiSpawner<T, P> : MonoBehaviour 
        where T: Component, ISpawnObject<T>
        where P: Component, ISpawnObject<P>
    {
        [field: SerializeField] public Spawner<T> SpawnerCubes { get; private set; }
        [field: SerializeField] public Spawner<P> SpawnerBombs { get; private set; }
    }
}
