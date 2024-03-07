using Rope.Services.Collectables;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterCollector : MonoBehaviour, ICollector
    {
        public void OnCollected(GameObject other)
        {
            Debug.Log("Star collected");
        }
    }
}