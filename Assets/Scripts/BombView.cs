using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(MeshRenderer), typeof(Rigidbody), typeof(Bomb))]
    public class BombView : MonoBehaviour
    {
        private float _alphaStart;
        private MeshRenderer _meshRenderer;
        private float _currentAlpha;
        private Color _spriteColor;
        private float _coomingAlpha = 0;
        private float _step = 1f;
        private Rigidbody _rigidbody;
        private Bomb _bomb;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            _bomb = GetComponent<Bomb>();
            _spriteColor = _meshRenderer.material.color;
            _currentAlpha = _spriteColor.a;
            _alphaStart = _spriteColor.a;
        }

        private void OnEnable()
        {
            _bomb.Timer.TickingPeriod += SetAlphaParametr;
        }

        private void OnDisable()
        {
            SetDefaultParametrs();
            _bomb.Timer.TickingPeriod -= SetAlphaParametr;
        }

        public void SetAlphaParametr(float coomingAlpha)
        {
            _coomingAlpha = coomingAlpha;
            _step = _currentAlpha - _coomingAlpha;
            StartCoroutine(SmoothChangeAphaParametr());
        }

        public void SetDefaultParametrs()
        {
            _spriteColor.a = _alphaStart;
            _currentAlpha = _spriteColor.a;
            _meshRenderer.material.color = _spriteColor;
            _rigidbody.velocity = Vector3.zero;
        }

        private IEnumerator SmoothChangeAphaParametr()
        {
            while (_currentAlpha > _coomingAlpha)
            {
                _spriteColor.a = Mathf.MoveTowards(_currentAlpha, _coomingAlpha, _step * Time.deltaTime);
                _currentAlpha = _spriteColor.a;
                _meshRenderer.material.color = _spriteColor;

                yield return null;
            }
        }
    }
}
