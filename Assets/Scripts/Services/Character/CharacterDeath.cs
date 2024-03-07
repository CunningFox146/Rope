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
        private static readonly int Fade = Shader.PropertyToID("_Fade");
        
        [SerializeField] private RopeMovement _movement;
        [SerializeField] private SpriteRenderer _renderer;

        public void Kill(GameObject killer)
        {
            Die();
        }
        
        private void Die()
        {
            _movement.enabled = false;
            Death?.Invoke();
            _renderer.material.DOFloat(0f, Fade, 0.5f)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}