using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GroundDetecter : MonoBehaviour
    {
        private bool _isCollisionWithGround = false;

        public event Action CollisedWithGround;

        public void OnDisable()
        {
            _isCollisionWithGround = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isCollisionWithGround == false)
            {
                if (collision.transform.TryGetComponent(out Ground ground))
                {
                    _isCollisionWithGround = true;
                    CollisedWithGround?.Invoke();
                }
            }
        }
    }
}
