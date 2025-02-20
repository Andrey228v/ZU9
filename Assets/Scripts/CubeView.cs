using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private Material[] _material;

        private Renderer _renderer;
        private bool _isCollisionWithGround = false;

        private int _startMaterial = 0;
        private int _collisionMaterial = 1;

        public event Action CollisedWithGround;

        private void Awake()
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

                    CollisedWithGround?.Invoke();
                }
            }
        }

        public void SetDefaultParametrs()
        {
            _isCollisionWithGround = false;
            _renderer.material = _material[_startMaterial];
        }
    }
}
