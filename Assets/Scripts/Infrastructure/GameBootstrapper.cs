using Rope.Infrastructure.CoroutineRunner;
using Rope.Services.Inputs;
using Rope.Services.SceneLoading;
using Rope.Services.States;
using UnityEngine;

namespace Rope.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public GameStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            RegisterServices(AllServices.Container);
            
            StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        private void RegisterServices(AllServices container)
        {
            container.RegisterSingle<ICoroutineRunner>(this);
            container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            container.RegisterSingle<IInputService>(new InputService(new MasterInput()));
            
            StateMachine = new GameStateMachine(container);
            container.RegisterSingle(StateMachine);
        }
    }
}