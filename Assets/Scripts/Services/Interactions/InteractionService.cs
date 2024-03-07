using System.Collections;
using Rope.Infrastructure;
using Rope.Infrastructure.CoroutineRunner;
using Rope.Services.Inputs;
using Rope.Util;
using UnityEngine;

namespace Rope.Services.Interactions
{
    public class InteractionService : IService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IInputService _inputService;
        private readonly Camera _camera;
        private IDraggable _currentDraggable;

        private Coroutine _draggableCoroutine;
        public bool IsInteracting => _currentDraggable is not null;
        public bool Enabled { get; set; } = true;

        public InteractionService(ICoroutineRunner coroutineRunner, IInputService inputService, Camera camera)
        {
            _coroutineRunner = coroutineRunner;
            _inputService = inputService;
            _camera = camera;

            RegisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            _inputService.Click += OnClick;
            _inputService.ClickCancelled += OnClickCancelled;
        }

        private void OnClick(Vector2 point)
        {
            var draggable = GetComponentAtPoint<IDraggable>(point);
            if (draggable is not null)
            {
                _currentDraggable = draggable;
                _draggableCoroutine = _coroutineRunner.StartCoroutine(DraggableCoroutine());
            }
        }

        private IEnumerator DraggableCoroutine()
        {
            while (Enabled && _currentDraggable is not null)
            {
                var pos = _camera.ScreenToWorldPoint(_inputService.PointerPosition);
                _currentDraggable.Drag(pos);
                yield return null;
            }
        }

        private void OnClickCancelled()
        {
            if (_draggableCoroutine is not null)
                _coroutineRunner.StopCoroutine(_draggableCoroutine);
            _currentDraggable = null;
        }
        
        private TComponent GetComponentAtPoint<TComponent>(Vector2 pos)
        {
            var point = new Vector3(pos.x, pos.y, _camera.nearClipPlane);
            var collider = Physics2D.OverlapPoint(_camera.ScreenToWorldPoint(point), 1 << (int)Layers.Rope);
            return collider ? collider.GetComponentInParent<TComponent>() : default;
        }
    }
}