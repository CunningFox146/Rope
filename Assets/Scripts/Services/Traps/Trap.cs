using System;
using UnityEngine;

namespace Rope.Services.Traps
{
    public class Trap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var killable = other.GetComponentInParent<IKillable>();
            killable?.Kill(gameObject);
        }
    }
}