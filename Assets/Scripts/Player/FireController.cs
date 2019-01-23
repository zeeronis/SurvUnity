using System.Collections;
using UnityEngine;

namespace Survive
{
    public class FireController : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bulletPrefab;

        [SerializeField]
        private Transform _bulletStartPosition;

        [SerializeField]
        private float _fireDelay;

        [SerializeField]
        private string _targetLayer;

        private Character _enemy;
        public Character Enemy => _enemy;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer) && _enemy == null)
            {
                var enemy = other.GetComponent<Character>();

                if (enemy != null)
                {
                    _enemy = enemy;
                    StartCoroutine("CoFire");
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer) && _enemy == null)
            {
                var enemy = other.GetComponent<Character>();

                if (enemy != null)
                {
                    _enemy = enemy;
                    StartCoroutine("CoFire");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer))
            {
                var enemy = other.GetComponent<Character>();

                if (enemy != null && _enemy == enemy)
                {
                    _enemy = null;
                    StopCoroutine("CoFire");
                }
            }
        }



        private IEnumerator CoFire()
        {
            while (true)
            {
                if (_enemy == null)
                {
                    break;
                }

                Vector3 targetPosition = _enemy.transform.position + new Vector3(0, 1);
                Vector3 direction = (targetPosition - _bulletStartPosition.position).normalized;
                var bullet = Instantiate(_bulletPrefab, _bulletStartPosition.position, Quaternion.identity);
                bullet.Init(direction);

                yield return new WaitForSeconds(_fireDelay);
            }
        }
    }
}


