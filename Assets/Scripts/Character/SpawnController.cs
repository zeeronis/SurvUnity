using System.Collections;
using UnityEngine;

namespace Survive
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField]
        private float _spawnDelay;

        [SerializeField]
        private Character _CharacterPrefab;

        private System.Random rnd = new System.Random();

        private void Start()
        {
            StartCoroutine("CoSpawn");
        }

        private IEnumerator CoSpawn()
        {
            while (true)
            {
                var characters = gameObject.GetComponentsInChildren<Character>();

                if(characters.Length < 20)
                {
                    Instantiate(
                        _CharacterPrefab, 
                        new Vector3(rnd.Next(-33, 33), 0f, rnd.Next(-33, 33)), 
                        Quaternion.identity, gameObject.transform);
                }

                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}

