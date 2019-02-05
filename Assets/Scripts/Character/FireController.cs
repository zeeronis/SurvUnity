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
            TriggeHandle(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggeHandle(other);
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


        private void TriggeHandle(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_targetLayer) && _enemy == null)
            {
                var enemy = other.GetComponent<Character>();

                if (enemy != null)
                {
                    _enemy = enemy;
                    StopAllCoroutines();
                    StartCoroutine("CoFire");                                                               //Improvement
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

                Vector3 direction = (_enemy.transform.position - _bulletStartPosition.position).normalized;
                direction.y = 0;
                var bullet = Instantiate(_bulletPrefab, _bulletStartPosition.position, Quaternion.identity);
                bullet.Init(direction);

                yield return new WaitForSeconds(_fireDelay);
            }
        }
    }
}


