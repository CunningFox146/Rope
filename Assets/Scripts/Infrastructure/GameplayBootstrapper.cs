﻿using Rope.Infrastructure.CoroutineRunner;
using Rope.Services;
using Rope.Services.EndPoint;
using Rope.Services.Inputs;
using Rope.Services.Interactions;
using Rope.Services.Rope;
using Rope.Services.Sound;
using Rope.Services.Spawner;
using Rope.Services.States;
using Rope.UI;
using UnityEngine;

namespace Rope.Infrastructure
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        [SerializeField] private SoundData _mainMusic;
        [SerializeField] private GameObject _characterSpawnerPrefab;
        [SerializeField] private GameObject _uiPrefab;
        private GameStateMachine _stateMachine;
        private ISoundPlayer _soundPlayer;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<GameStateMachine>();
            _soundPlayer = AllServices.Container.Single<ISoundPlayer>();
        }

        private void Start()
        {
            RegisterSceneServices(AllServices.Container);
            RegisterSceneStates(AllServices.Container);

            _soundPlayer.Play(_mainMusic);
            
            _stateMachine.Enter<GameplayLoopState>();
        }

        private void RegisterSceneServices(AllServices container)
        {
            container.RegisterSingleFromHierarchy<RopeRenderer>();
            container.RegisterSingleFromHierarchy<EndPointService>();
            container.RegisterSingle(new InteractionService(container.Single<ICoroutineRunner>(),
                container.Single<IInputService>(), Camera.main));
            container.RegisterSingleFromNewPrefab<CharacterSpawner>(_characterSpawnerPrefab);
            container.RegisterSingleFromNewPrefab<UserInterfaceSystem>(_uiPrefab);
        }

        private void RegisterSceneStates(AllServices container)
        {
            _stateMachine.RegisterState(new GameplayLoopState(_stateMachine, container.Single<IInputService>(),
                container.Single<ICoroutineRunner>(), container.Single<EndPointService>(),
                container.Single<CharacterSpawner>(), container.Single<InteractionService>()));
        }
    }
}