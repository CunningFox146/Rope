using System;
using Rope.Services.Movement;
using Rope.Util;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterDeath : MonoBehaviour
    {
        public event Action Death;
        
        [SerializeField] private RopeMovement _movement;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == (int)Layers.Obstacle)
                Die();
        }

        private void Die()
        {
            _movement.enabled = false;
            Death?.Invoke();
        }
    }
}