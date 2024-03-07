using System;
using UnityEngine;

namespace Rope.Services.Collectables
{
    public class Collectable : MonoBehaviour
    {
        public event Action Collected;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!enabled)
                return;
            
            var collector = other.GetComponentInParent<ICollector>();
            if (collector is not null)
            {
                collector.OnCollected(gameObject);
                Collected?.Invoke();
                enabled = false;
            }
        }
    }
}