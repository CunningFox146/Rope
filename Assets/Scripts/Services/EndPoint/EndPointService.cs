using Rope.Infrastructure;
using UnityEngine;

namespace Rope.Services.EndPoint
{
    public class EndPointService : MonoBehaviour, IService
    {
        [SerializeField] private Transform _ropeEnd;
        [SerializeField] private float _distance;

        public bool IsRopeNear => Vector3.Distance(transform.position, _ropeEnd.position) < _distance;
    }
}