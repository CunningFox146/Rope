using System.Collections;
using Rope.Infrastructure.CoroutineRunner;
using Rope.Infrastructure.States;
using Rope.Services.EndPoint;
using Rope.Services.Inputs;
using Rope.Services.Interactions;
using Rope.Services.Spawner;
using UnityEngine;

namespace Rope.Services.States
{
    public class GameplayLoopState : IState, IExitableState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EndPointService _endPointService;
        private readonly CharacterSpawner _characterSpawner;
        private readonly InteractionService _interactionService;
        private readonly WaitForSeconds _releaseDelay = new(0.25f);
        private Coroutine _holdCoroutine;

        public GameplayLoopState(GameStateMachine stateMachine, IInputService inputService, ICoroutineRunner coroutineRunner, EndPointService endPointService, CharacterSpawner characterSpawner, InteractionService interactionService)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _coroutineRunner = coroutineRunner;
            _endPointService = endPointService;
            _characterSpawner = characterSpawner;
            _interactionService = interactionService;
        }

        public void Enter()
        {
            _inputService.Hold += OnHold;
            _inputService.HoldCancelled += OnHoldCancelled;
        }

        public void Exit()
        {
            StopMovementCoroutine();
            
            _inputService.Hold -= OnHold;
            _inputService.HoldCancelled -= OnHoldCancelled;
        }

        private void OnHold(Vector2 pos)
        {
            if (_holdCoroutine is null && _endPointService.IsRopeNear)
                _holdCoroutine = _coroutineRunner.StartCoroutine(HoldCoroutine());
        }

        private IEnumerator HoldCoroutine()
        {
            while (!_interactionService.IsInteracting)
            {
                _characterSpawner.ReleaseCharacter();
                yield return _releaseDelay;
            }
        }

        private void OnHoldCancelled()
        {
            StopMovementCoroutine();
        }

        private void StopMovementCoroutine()
        {
            if (_holdCoroutine is null)
                return;
            
            _coroutineRunner.StopCoroutine(_holdCoroutine);
            _holdCoroutine = null;
        }
    }
}