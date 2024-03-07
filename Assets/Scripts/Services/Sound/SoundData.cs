using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Rope.Services.Sound
{
    [CreateAssetMenu(menuName = "Static Data/Sound Data")]
    public class SoundData : ScriptableObject
    {
        [field: SerializeField] public float Volume { get; set; }
        [field: SerializeField] public bool IsLoop { get; set; }
        [field: SerializeField] public AudioMixerGroup AudioMixerGroup { get; set; }
        [field: SerializeField] public List<AudioClip> Clips { get; set; }
    }
}