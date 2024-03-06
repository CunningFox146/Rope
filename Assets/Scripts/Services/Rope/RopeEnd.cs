using System;
using DG.Tweening;
using Rope.Services.EndPoint;
using UnityEngine;

namespace Rope.Services.Rope
{
    public class RopeEnd : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private EndPointService _endPoint;
        [SerializeField] private Color _nearColor;
        private Color _startColor;
        private Tween _colorAnim;
        private bool _isNear;

        private void Awake()
        {
            _startColor = _spriteRenderer.color;
        }

        private void FixedUpdate()
        {
            if (_endPoint.IsRopeNear)
                DisplayIsNear();
            else
                DisplayIsFar();
        }

        private void DisplayIsFar()
        {
            if (!_isNear)
                return;

            _isNear = false;
            _colorAnim?.Kill();
            _colorAnim = _spriteRenderer.DOColor(_startColor, 0.5f);
        }

        private void DisplayIsNear()
        {
            if (_isNear)
                return;

            _isNear = true;
            _colorAnim?.Kill();
            _colorAnim = _spriteRenderer.DOColor(_nearColor, 0.5f);
        }
    }
}