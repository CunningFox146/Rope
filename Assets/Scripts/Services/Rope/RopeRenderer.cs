using System.Collections.Generic;
using System.Linq;
using Rope.Infrastructure;
using Rope.Util;
using UnityEditor;
using UnityEngine;

namespace Rope.Services.Rope
{
    public class RopeRenderer : MonoBehaviour, IService
    {
        [SerializeField] private float _additionalRadius = 0.05f;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private readonly List<Vector3> _points = new();
        private Transform _activeEndPoint;
        private Vector2 _activeStartPoint;
        private Vector3 _lastPos;
        
        public List<Vector3> RenderPoints { get; private set; } = new();

        private void Update()
        {
            RenderLine();
        }

        private void FixedUpdate()
        {
            if (_activeEndPoint.position == _lastPos)
                return;

            ValidatePoints();
            BuildRopePath();

            _lastPos = _activeEndPoint.position;
        }

        private void OnEnable()
        {
            _lineRenderer.Reset();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Handles.color = Color.black;
            foreach (var point in _points)
            {
                Handles.Label(point + Vector3.back, _points.IndexOf(point).ToString());
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
#endif

        private void Start()
        {
            _activeStartPoint = _startPoint.position;
            _activeEndPoint = _endPoint;
        }

        private void ValidatePoints()
        {
            if (_points.Count <= 1)
                ValidateLastPoint();
            else
                ValidateAllPoints();
        }

        private void ValidateAllPoints()
        {
            var points = _points.AsReadOnly().Reverse();
            foreach (var point in points)
            {
                if (Physics2D.Linecast(_activeEndPoint.position, point, 1 << (int)Layers.Obstacle))
                    break;
                _points.Remove(point);
            }
        }

        private void ValidateLastPoint()
        {
            if (Physics2D.Linecast(_startPoint.position, _activeEndPoint.position, 1 << (int)Layers.Obstacle))
                return;

            _points.Clear();
            _activeStartPoint = _startPoint.position;
        }

        private void RenderLine()
        {
            RenderPoints.Clear();
            RenderPoints.Add(_startPoint.position);
            RenderPoints.AddRange(_points);
            RenderPoints.Add(_activeStartPoint);
            RenderPoints.Add(_activeEndPoint.position);

            _lineRenderer.positionCount = RenderPoints.Count;
            for (var i = 0; i < RenderPoints.Count; i++) _lineRenderer.SetPosition(i, RenderPoints[i]);
        }

        private void BuildRopePath()
        {
            var startPoint = _activeStartPoint;
            var endPoint = _activeEndPoint.position;
            while (true)
            {
                var hit = Physics2D.Linecast(startPoint, endPoint, 1 << (int)Layers.Obstacle);
                if (!hit || hit.collider is not CircleCollider2D circle)
                    break;

                var radius = circle.radius + _additionalRadius;
                var circlePos = (Vector2)circle.transform.position;
                var direction = (hit.point - circlePos).normalized;
                var newPoint = circlePos + direction * radius;
                startPoint = newPoint;
                _points.Add(newPoint);
            }

            if (_points.Any())
                _activeStartPoint = _points.Last();
        }
    }
}