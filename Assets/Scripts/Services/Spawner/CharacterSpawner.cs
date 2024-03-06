using System;
using UnityEngine;

namespace Rope.Services.Spawner
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private int _characterCount;
        [SerializeField] private float _size;

        private void Start()
        {
            SpawnCharacters(_characterCount);
        }

        private void OnDrawGizmosSelected()
        {
            var startOffset = Vector3.left * _size * 0.5f;
            for (var i = 0; i < _characterCount; i++)
            {
                Gizmos.DrawSphere(transform.position + startOffset + Vector3.right * (_size * (1 + i)/_characterCount), 0.5f);
            }
        }

        private void SpawnCharacters(int characterCount)
        {
            var startOffset = Vector3.left * _size * 0.5f;
            for (var i = 0; i < characterCount; i++)
            {
                Instantiate(_characterPrefab, transform.position + startOffset + Vector3.right * (_size * (1 + i)/characterCount), Quaternion.identity);
            }
        }
    }
}