using Assets.Scripts.SpawnPositionType;
using System;

namespace Assets.Scripts
{
    public interface ISpawnerType
    {
        public event Action Spawned;

        public ISpawnPosition SpawnPosition { get; }

        public void Spawn();
    }
}
