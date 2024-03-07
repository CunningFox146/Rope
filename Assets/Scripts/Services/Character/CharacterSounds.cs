using Rope.Services.Movement;
using Rope.Services.Sound;
using UnityEngine;

namespace Rope.Services.Character
{
    public class CharacterSounds : MonoBehaviour
    {
        [SerializeField] private SoundData _moveSound;
        [SerializeField] private SoundData _deathSound;
        [SerializeField] private SoundData _winSound;
        [SerializeField] private SoundData _collectSound;
        [SerializeField] private CharacterDeath _death;
        [SerializeField] private RopeMovement _movement;
        [SerializeField] private CharacterCollector _collector;
        private ISoundPlayer _sound;

        private void Awake()
        {
            _sound = AllServices.Container.Single<ISoundPlayer>();
        }

        private void OnEnable()
        {
            _death.Death += OnDeath;
            _collector.Collect += OnCollected;
            _movement.Move += OnMove;
            _movement.ReachDestination += OnReachDestination;
        }


        private void OnDisable()
        {
            _death.Death -= OnDeath;
            _movement.Move -= OnMove;
            _collector.Collect += OnCollected;
            _movement.ReachDestination -= OnReachDestination;
        }

        private void OnMove()
        {
            _sound.Play(_moveSound);
        }

        private void OnDeath()
        {
            _sound.Play(_deathSound);
        }

        private void OnCollected()
        {
            _sound.Play(_collectSound);
        }
        
        private void OnReachDestination()
        {
            _sound.Play(_winSound);
        }
    }
}