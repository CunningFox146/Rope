using DG.Tweening;
using Rope.Services.Movement;
using Rope.Util;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Rope.Services.Character
{
    public class CharacterLight : MonoBehaviour
    {
        [SerializeField] private RopeMovement _movement;
        [SerializeField] private CharacterDeath _death;
        [SerializeField] private Light2D _light;
        
        private float _startIntensity;
        private Tween _intensityTween;

        private void OnEnable()
        {
            _startIntensity = _light.intensity;
            _light.intensity = 0f;
            
            _movement.Move += OnMove;
            _death.Death += OnDeath;
        }

        private void OnDisable()
        {
            _movement.Move -= OnMove;
            _death.Death -= OnDeath;
        }

        private void OnMove()
        {
            _intensityTween?.Kill();
            _intensityTween = _light.DOIntensity(_startIntensity, 0.5f);
        }
        
        private void OnDeath()
        {
            _intensityTween?.Kill();
            _intensityTween = _light.DOIntensity(0f, 0.5f);
        }
    }
}