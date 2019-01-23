using UnityEngine;

namespace Survive
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _damage;
        [SerializeField]
        private float _maxLifetime;
        [SerializeField]
        private Rigidbody _rigidbody;

        private Vector3 _direction;
        #endregion

        public float Damage => _damage;

        #region Unity Lifecycle
        private void Update()
        {
            _rigidbody.velocity = _direction * _speed;

            Quaternion rotation = Quaternion.LookRotation(_direction, Vector3.up);
            _rigidbody.rotation = rotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
        #endregion

        #region Public Methods
        public void Init(Vector3 direction)
        {
            _direction = direction;

            Destroy(gameObject, _maxLifetime);
        }
        #endregion
    }
}