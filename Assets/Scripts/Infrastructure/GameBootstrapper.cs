using Rope.Infrastructure.CoroutineRunner;
using Rope.Services.SceneLoading;
using Rope.Services.States;
using UnityEngine;

namespace Rope.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            RegisterServices(AllServices.Container);
            
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        private void RegisterServices(AllServices container)
        {
            container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
        }
    }
}