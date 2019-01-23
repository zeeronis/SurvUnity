using UnityEngine;

namespace Survive
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _hp;

        [SerializeField]
        private string _damageLayer;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_damageLayer))
            {
                _hp -= other.gameObject.GetComponent<Bullet>().Damage;
                if (_hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
