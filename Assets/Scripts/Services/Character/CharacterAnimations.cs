using System;
using Rope.Services.Movement;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private CharacterDeath _death;
        [SerializeField] private RopeMovement _movement;

        private void OnEnable()
        {
            _death.Death += OnDeath;
            _movement.Move += OnMove;
        }

        private void OnDisable()
        {
            _death.Death -= OnDeath;
            _movement.Move -= OnMove;
        }

        private void OnMove()
        {
            throw new NotImplementedException();
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}