using UnityEngine;

namespace Rope.Services.Interactions
{
    public interface IDraggable
    {
        void Drag(Vector2 pos);
    }
}