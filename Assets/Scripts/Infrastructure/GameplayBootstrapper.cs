using Rope.Infrastructure.CoroutineRunner;
using Rope.Services;
using Rope.Services.EndPoint;
using Rope.Services.Inputs;
using Rope.Services.Interactions;
using Rope.Services.Rope;
using Rope.Services.Spawner;
using Rope.Services.States;
using UnityEngine;

namespace Rope.Infrastructure
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<GameStateMachine>();
        }

        private void Start()
        {
            RegisterSceneServices(AllServices.Container);
            RegisterSceneStates(AllServices.Container);

            _stateMachine.Enter<GameplayLoopState>();
        }

        private void RegisterSceneServices(AllServices container)
        {
            container.RegisterSingleFromHierarchy<RopeRenderer>();
            container.RegisterSingleFromHierarchy<EndPointService>();
            container.RegisterSingleFromHierarchy<CharacterSpawner>();
            container.RegisterSingle(new InteractionService(container.Single<ICoroutineRunner>(),
                container.Single<IInputService>(), Camera.main));
        }

        private void RegisterSceneStates(AllServices container)
        {
            _stateMachine.RegisterState(new GameplayLoopState(_stateMachine, container.Single<IInputService>(),
                container.Single<ICoroutineRunner>(), container.Single<EndPointService>(),
                container.Single<CharacterSpawner>(), container.Single<InteractionService>()));
        }
    }
}