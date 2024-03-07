using System;
using System.Collections.Generic;
using System.Linq;
using Rope.Infrastructure;
using Rope.Services.Character;
using Rope.Services.Interactions;
using Rope.Services.Movement;
using Rope.Services.Rope;
using UnityEngine;

namespace Rope.Services.Spawner
{
    public class CharacterSpawner : MonoBehaviour, IService
    {
        public event Action NoCharacters;
        [SerializeField] private RopeMovement _characterPrefab;
        [SerializeField] private int _characterCount;
        [SerializeField] private float _size;
        
        private readonly List<RopeMovement> _activeCharacters = new();
        private readonly Stack<RopeMovement> _spawnedCharacters = new();
        private InteractionService _interactionService;
        private RopeRenderer _ropeRenderer;

        private void Start()
        {
            _interactionService = AllServices.Container.Single<InteractionService>();
            _ropeRenderer = AllServices.Container.Single<RopeRenderer>();
            SpawnCharacters(_characterCount);
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
            if (!_spawnedCharacters.TryPop(out var character))
                return;

            var characterDeath = character.GetComponent<CharacterDeath>();
            
            character.StartMoving(_ropeRenderer.RenderPoints);
            _activeCharacters.Add(character);

            character.ReachDestination += OnReachDestination;
            characterDeath.Death += OnDeath;
            
            UpdateActiveCharacters();

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
            var hasAnyActiveCharacters = _activeCharacters.Any();
            _interactionService.Enabled = !hasAnyActiveCharacters;
            if (!_spawnedCharacters.Any() && !hasAnyActiveCharacters)
                NoCharacters?.Invoke();
        }
    }
}