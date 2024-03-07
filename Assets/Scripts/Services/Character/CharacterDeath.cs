using System;
using DG.Tweening;
using Rope.Services.Movement;
using Rope.Services.Traps;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterDeath : MonoBehaviour, IKillable
    {
        public event Action Death;
        
        [SerializeField] private RopeMovement _movement;

        public void Kill(GameObject killer)
        {
            Die();
        }
        
        private void Die()
        {
            _movement.enabled = false;
            Death?.Invoke();
        }
    }
}