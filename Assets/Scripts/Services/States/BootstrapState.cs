using Rope.Infrastructure.States;
using Rope.Services.SceneLoading;

namespace Rope.Services.States
{
    public class BootstrapState : IState
    {
        private readonly ISceneLoader _sceneLoader; 
            
        public BootstrapState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Gameplay);
        }
    }
}