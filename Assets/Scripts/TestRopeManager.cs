using System.Collections.Generic;
using System.Linq;
using Rope.Util;
using UnityEditor;
using UnityEngine;

namespace Rope
{
    public class TestRopeManager : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private readonly List<Vector3> _points = new();
        private readonly List<Vector3> _renderPoints = new();
        private Transform _activeEndPoint;
        private Vector2 _activeStartPoint;
        private Vector3 _lastPos;

        private void Start()
        {
            _activeStartPoint = _startPoint.position;
            _activeEndPoint = _endPoint;
        }

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
                if (Physics2D.Linecast(_activeEndPoint.position, point))
                    break;
                _points.Remove(point);
            }
        }

        private void ValidateLastPoint()
        {
            if (Physics2D.Linecast(_startPoint.position, _activeEndPoint.position))
                return;

            _points.Clear();
            _activeStartPoint = _startPoint.position;
        }

        private void RenderLine()
        {
            _renderPoints.Clear();
            _renderPoints.Add(_startPoint.position);
            _renderPoints.AddRange(_points);
            _renderPoints.Add(_activeStartPoint);
            _renderPoints.Add(_activeEndPoint.position);

            _lineRenderer.positionCount = _renderPoints.Count;
            for (var i = 0; i < _renderPoints.Count; i++) _lineRenderer.SetPosition(i, _renderPoints[i]);
        }

        private void BuildRopePath()
        {
            var startPoint = _activeStartPoint;
            var endPoint = _activeEndPoint.position;
            while (true)
            {
                var hit = Physics2D.Linecast(startPoint, endPoint);
                if (!hit || hit.collider is not CircleCollider2D circle)
                    break;

                var radius = circle.radius + 0.01f;
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