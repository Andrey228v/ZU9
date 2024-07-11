using System.Collections;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField] private int _size = 1;
    [SerializeField] private Material[] _material;
    
    private Spawner _spawner;
    private Renderer _renderer;
    private bool _isCollisionWithGround = false;

    private int _minTimeLife = 2;
    private int _maxTimeLife = 5;
    int _startMaterial = 0;
    int _collisionMaterial = 1;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _material[_startMaterial];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isCollisionWithGround == false)
        {
            if (collision.transform.TryGetComponent(out Ground ground))
            {
                _renderer.material = _material[_collisionMaterial];
                _isCollisionWithGround = true;

                StartCoroutine(StartTimerDestroy());
            }
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        _spawner = spawner;
    }

    private IEnumerator StartTimerDestroy()
    {
        while (true)
        {
            int timeLife = Random.Range(_minTimeLife, _maxTimeLife);

            yield return new WaitForSeconds(timeLife);

            _spawner.ReturnToPool(this);
            _isCollisionWithGround = false;
            _renderer.material = _material[_startMaterial];
        }
    }
}
