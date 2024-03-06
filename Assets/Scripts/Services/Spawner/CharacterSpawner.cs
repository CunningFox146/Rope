using System.Collections.Generic;
using Rope.Infrastructure;
using Rope.Services.Movement;
using Rope.Services.Rope;
using UnityEngine;

namespace Rope.Services.Spawner
{
    public class CharacterSpawner : MonoBehaviour, IService
    {
        [SerializeField] private RopeMovement _characterPrefab;
        [SerializeField] private RopeRenderer _ropeRenderer;
        [SerializeField] private int _characterCount;
        [SerializeField] private float _size;
        
        private readonly Stack<RopeMovement> _spawnedCharacters = new(); 

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
                var pos = transform.position + startOffset + Vector3.right * (_size * (1 + i) / characterCount);
                var character = Instantiate(_characterPrefab, pos, Quaternion.identity);
                _spawnedCharacters.Push(character);
            }
        }

        public void ReleaseCharacter()
        {
            if (!_spawnedCharacters.TryPop(out var spawnedCharacter))
                return;
            
            spawnedCharacter.StartMoving(_ropeRenderer.RenderPoints, null);
        }
    }
}