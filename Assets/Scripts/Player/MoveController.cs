using Survive;
using UnityEngine;

namespace Survive
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _movementSpeed;

        void Update()
        {
            Vector3 direction = new Vector3(InputController.Instance.MoveDirection.x, 0,
                InputController.Instance.MoveDirection.y);

            _rigidbody.velocity = direction * _movementSpeed;

            Character enemy = gameObject.GetComponent<FireController>().Enemy;
           
            if (enemy != null)
            {
                Vector3 enemyDirection =  (enemy.gameObject.transform.position  
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
