using System;
using Rope.Services.Render;
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
            
            _stateMachine.Enter<GameplayInitState>();
        }

        private void RegisterSceneServices(AllServices container)
        {
            container.RegisterSingleFromHierarchy<RopeRenderer>();
        }

        private void RegisterSceneStates(AllServices container)
        {
            _stateMachine.RegisterState(new GameplayInitState(_stateMachine, container.Single<RopeRenderer>()));
        }
    }
}