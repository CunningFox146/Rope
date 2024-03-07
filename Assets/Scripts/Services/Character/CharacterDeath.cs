using System;
using Rope.Services.Movement;
using Rope.Services.Traps;
using Rope.Util;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterDeath : MonoBehaviour, IKillable
    {
        public event Action Death;
        
        [SerializeField] private RopeMovement _movement;
        
        private void Die()
        {
            _movement.enabled = false;
            Death?.Invoke();
        }

        public void Kill(GameObject killer)
        {
            Die();
        }
    }
}