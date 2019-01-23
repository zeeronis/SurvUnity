using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survive
{
    public class EnemyMoveController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _movementSpeed;

        private void Update()
        {
            if (InputController.Instance == null) return;

            Vector3 direction = (InputController.Instance.gameObject.transform.position
                - gameObject.transform.position).normalized;

            _rigidbody.velocity = direction * _movementSpeed;

            Character enemy = gameObject.GetComponent<FireController>().Enemy;

            if (enemy != null)
            {
                Vector3 enemyDirection = (enemy.gameObject.transform.position
                    - gameObject.transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(enemyDirection, Vector3.up);
                _rigidbody.rotation = rotation;
            }
            else
            {
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                _rigidbody.rotation = rotation;
            }

        }
    }
}


