using UnityEngine;

namespace Rope.Services.Traps
{
    public class InfiniteRotation : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void Update()
        {
            transform.Rotate(Vector3.forward * (_speed * Time.deltaTime));
        }
    }
}