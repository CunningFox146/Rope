using System;
using Rope.Infrastructure;
using UnityEngine;

namespace Rope.Services.Inputs
{
    public interface IInputService : IService
    {
        event Action<Vector2> Click;
        event Action ClickCancelled;
        event Action<Vector2> Hold;
        event Action HoldCancelled;
        
        public Vector2 PointerPosition { get; }
    }
}