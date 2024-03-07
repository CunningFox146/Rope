using System;
using System.Collections.Generic;
using System.Linq;
using Rope.Infrastructure;
using Rope.Services.Character;
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
        private readonly List<RopeMovement> _activeCharacters = new();

        private readonly Stack<RopeMovement> _spawnedCharacters = new();

        private void Start()
        {
            SpawnCharacters(_characterCount);
        }

        public event Action NoCharacters;

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
            if (!_spawnedCharacters.TryPop(out var character))
                return;

            var characterDeath = character.GetComponent<CharacterDeath>();
            
            character.StartMoving(_ropeRenderer.RenderPoints);
            _activeCharacters.Add(character);

            character.ReachDestination += OnReachDestination;
            characterDeath.Death += OnDeath;

            void OnReachDestination()
            {
                character.ReachDestination -= OnReachDestination;
                _activeCharacters.Remove(character);
                UpdateActiveCharacters();
            }

            void OnDeath()
            {
                characterDeath.Death -= OnDeath;
                _activeCharacters.Remove(character);
                UpdateActiveCharacters();
            }
        }

        private void UpdateActiveCharacters()
        {
            if (!_spawnedCharacters.Any() && !_activeCharacters.Any())
                NoCharacters?.Invoke();
        }
    }
}