using Rope.Infrastructure.States;
using Rope.Services.SceneLoading;

namespace Rope.Services.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader; 
            
        public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Gameplay);
        }
    }
}