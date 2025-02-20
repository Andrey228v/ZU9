using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class SpawnInformation<T> : MonoBehaviour where T: Component, ISpawnObject<T>
    {
        [SerializeField] private Spawner<T> _spawner;
        [SerializeField] private TMP_Text _textAllCountSpawnObjects;
        [SerializeField] private TMP_Text _textCountCreateObjects;
        [SerializeField] private TMP_Text _textActiveObjects;

        private int _allCountSpawn = 0;
        private int _allCountCreate = 0;
        private int _activeObjects = 0;

        private void Start()
        {
            _spawner.SpawnerType.Spawned += SetTextAllCountSpawnObjects;
            _spawner.PoolFigure.Created += SetTextCountCreateObjects;
            _spawner.SpawnerType.Spawned += IncreaseTextActiveObjects;
            _spawner.PoolFigure.Destroyed += ReduseTextActiveObjects;
        }

        private void OnDisable()
        {
            _spawner.SpawnerType.Spawned -= SetTextAllCountSpawnObjects;
            _spawner.PoolFigure.Created -= SetTextCountCreateObjects;
            _spawner.SpawnerType.Spawned -= IncreaseTextActiveObjects;
            _spawner.PoolFigure.Destroyed -= ReduseTextActiveObjects;
        }

        private void SetTextAllCountSpawnObjects() 
        {
            _allCountSpawn++;
            _textAllCountSpawnObjects.SetText(_allCountSpawn.ToString());
        }

        private void SetTextCountCreateObjects()
        {
            _allCountCreate++;
            _textCountCreateObjects.SetText(_allCountCreate.ToString());
        }

        private void IncreaseTextActiveObjects()
        {
            _activeObjects++;
            _textActiveObjects.SetText(_activeObjects.ToString());
        }

        private void ReduseTextActiveObjects()
        {
            _activeObjects--;
            _textActiveObjects.SetText(_activeObjects.ToString());
        }
    }
}
