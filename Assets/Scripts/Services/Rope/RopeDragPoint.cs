using Rope.Services.Interactions;
using UnityEngine;

namespace Rope.Services.Rope
{
    public class RopeDragPoint : MonoBehaviour, IDraggable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        public void Drag(Vector2 pos)
            => _rigidbody.position = pos;
    }
}