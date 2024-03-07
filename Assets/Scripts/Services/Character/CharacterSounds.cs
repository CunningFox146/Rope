using System;
using Rope.Services.Movement;
using Rope.Services.Sound;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterSounds : MonoBehaviour
    {
        [SerializeField] private SoundData _deathSound;
        [SerializeField] private SoundData _winSound;
        [SerializeField] private CharacterDeath _death;
        [SerializeField] private RopeMovement _movement;
        private ISoundPlayer _sound;

        private void Awake()
        {
            _sound = AllServices.Container.Single<ISoundPlayer>();
        }

        private void OnEnable()
        {
            _death.Death += OnDeath;
            _movement.ReachDestination += OnReachDestination;
        }

        private void OnDisable()
        {
            _death.Death -= OnDeath;
            _movement.ReachDestination -= OnReachDestination;
        }

        private void OnDeath()
        {
            _sound.Play(_deathSound);
        }

        private void OnReachDestination()
        {
            _sound.Play(_winSound);
        }
    }
}