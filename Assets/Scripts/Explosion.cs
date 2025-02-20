using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _force;

        private bool _isActivated = true;

        public event Action Exploded;

         public void CreateExplosion()
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_force, transform.position, _radius);
                }
            }

            Exploded?.Invoke();
        }
    }
}
