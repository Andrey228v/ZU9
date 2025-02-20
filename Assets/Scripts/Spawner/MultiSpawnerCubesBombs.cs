namespace Assets.Scripts.Spawner
{
    public class MultiSpawnerCubesBombs : MultiSpawner<Cube, Bomb>
    {
        private void OnEnable()
        {
            SpawnerCubes.PoolFigure.Despawned += SpawnerBombs.SpawnerType.SpawnPosition.SetPoinForSpawn;
            SpawnerBombs.SpawnerType.SpawnPosition.SetedPointForSpawn += SpawnerBombs.SpawnerType.Spawn;
        }

        private void Start()
        {
            SpawnerCubes.SpawnerType.Spawn();
        }

        private void OnDisable()
        {
            SpawnerCubes.PoolFigure.Despawned -= SpawnerBombs.SpawnerType.SpawnPosition.SetPoinForSpawn;
            SpawnerBombs.SpawnerType.SpawnPosition.SetedPointForSpawn -= SpawnerBombs.SpawnerType.Spawn;
        }
    }
}
