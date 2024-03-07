using System;
using Rope.Services.Collectables;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterCollector : MonoBehaviour, ICollector
    {
        public event Action Collect;
        public void OnCollected(GameObject other)
        {
            Debug.Log("Star collected");
            Collect?.Invoke();
        }
    }
}