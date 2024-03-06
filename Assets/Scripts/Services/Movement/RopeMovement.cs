using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rope.Services.Movement
{
    public class RopeMovement : MonoBehaviour
    {
        public event Action Move;
        
        [SerializeField] private float _minDistance;
        [SerializeField] private float _speed = 1f;
        private Coroutine _movementCoroutine;

        private void OnDisable()
        {
            StopMoving();
        }

        public void StartMoving(List<Vector3> points, Action onMovementDone)
        {
            StopMoving();
            _movementCoroutine = StartCoroutine(MovementCoroutine(points.ToList(), onMovementDone));
        }

        private void StopMoving()
        {
            if (_movementCoroutine is not null)
                StopCoroutine(_movementCoroutine);
        }

        private IEnumerator MovementCoroutine(List<Vector3> points, Action onMovementDone)
        {
            foreach (var point in points)
            {
                while (Vector2.Distance(transform.position, point) > _minDistance)
                {
                    transform.Translate((point - transform.position).normalized * (Time.deltaTime * _speed));
                    yield return null;
                }
            }
            onMovementDone?.Invoke();
        }
    }
}