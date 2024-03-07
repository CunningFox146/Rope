using System;
using DG.Tweening;
using Rope.Services.Movement;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterAnimations : MonoBehaviour
    {
        private static readonly int Fade = Shader.PropertyToID("_Fade");
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private ParticleSystem _particles;
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
            
        }

        private void OnDeath()
        {
            _particles.Play();
            DOTween.Sequence()
                .Append(transform.DOMoveY(0.25f, 0.5f).SetRelative(true))
                .Append(_renderer.material.DOFloat(0f, Fade, 1f))
                .OnComplete(() => Destroy(gameObject));
        }
    }
}