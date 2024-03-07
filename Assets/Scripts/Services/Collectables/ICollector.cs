using UnityEngine;

namespace Rope.Services.Collectables
{
    public interface ICollector
    {
        void OnCollected(GameObject other);
    }
}