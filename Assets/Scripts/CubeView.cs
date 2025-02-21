using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer), typeof(Cube))]
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private Material[] _materials;

        private Renderer _renderer;
        private Cube _cube;

        private int _startMaterial = 0;
        private int _collisionMaterial = 1;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _cube = GetComponent<Cube>();
            _renderer.material = _materials[_startMaterial];
        }

        private void OnEnable()
        {
            _cube.GroundDetecter.CollisedWithGround += SetCollisionParametrs;
            _cube.CubeDestroyer.Destroed += SetDefaultParametrs;
        }

        private void OnDisable()
        {
            _cube.GroundDetecter.CollisedWithGround -= SetCollisionParametrs;
            _cube.CubeDestroyer.Destroed -= SetDefaultParametrs;
        }

        public void SetCollisionParametrs()
        {
            _renderer.material = _materials[_collisionMaterial];
        }

        public void SetDefaultParametrs()
        {
            _renderer.material = _materials[_startMaterial];
        }
    }
}
