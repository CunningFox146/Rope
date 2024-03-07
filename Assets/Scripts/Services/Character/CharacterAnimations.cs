using System;
using DG.Tweening;
using Rope.Services.EndPoint;
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
        private EndPointService _endPoint;

        private void OnEnable()
        {
            _death.Death += OnDeath;
            _movement.Move += OnMove;
            _movement.ReachDestination += OnReachDestination;
        }

        private void OnDisable()
        {
            _death.Death -= OnDeath;
            _movement.Move -= OnMove;
            _movement.ReachDestination -= OnReachDestination;
        }

        private void Start()
        {
            _endPoint = AllServices.Container.Single<EndPointService>();
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
        
        private void OnReachDestination()
        {
            DOTween.Sequence()
                .Append(transform.DOMove(_endPoint.transform.position, 0.25f))
                .Join(transform.DOScale(Vector3.one * 1.15f, 0.25f))
                .Append(transform.DOScale(Vector3.zero, 1f).SetEase(Ease.OutSine))
                .Join(_renderer.DOFade(0f, 1f))
                .OnComplete(() => Destroy(gameObject));
        }
    }
}