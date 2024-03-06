using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rope.Services.Inputs
{
    public class InputService : IDisposable, IInputService
    {
        public event Action<Vector2> Click;
        public event Action ClickCancelled;
        public event Action<Vector2> Hold;
        public event Action HoldCancelled;
        
        private readonly MasterInput _input;

        private Vector2 ClickPosition => _input.Generic.ClickPosition.ReadValue<Vector2>();

        public InputService(MasterInput input)
        {
            _input = input;
            InitInput();
        }

        private void InitInput()
        {
            _input.Generic.Enable();
            
            _input.Generic.Click.performed += OnClickPerformed;
            _input.Generic.Click.canceled += OnClickCancelled;
            _input.Generic.Hold.performed += OnHoldPerformed;
            _input.Generic.Hold.canceled += OnHoldCancelled;
        }

        public void Dispose()
        {
            _input.Generic.Click.performed -= OnClickPerformed;
            _input.Generic.Click.canceled -= OnClickCancelled;
            _input.Generic.Hold.performed -= OnHoldPerformed;
            _input.Generic.Hold.canceled -= OnHoldCancelled;
        }
        
        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            Click?.Invoke(ClickPosition);
        }

        private void OnHoldPerformed(InputAction.CallbackContext obj)
        {
            Hold?.Invoke(ClickPosition);
        }

        private void OnClickCancelled(InputAction.CallbackContext obj)
        {
            ClickCancelled?.Invoke();
        }

        private void OnHoldCancelled(InputAction.CallbackContext obj)
        {
            HoldCancelled?.Invoke();
        }
    }
}