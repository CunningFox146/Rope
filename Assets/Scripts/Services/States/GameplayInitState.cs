using Rope.Infrastructure.States;
using Rope.Services.Render;

namespace Rope.Services.States
{
    public class GameplayInitState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly RopeRenderer _ropeRenderer;

        public GameplayInitState(GameStateMachine stateMachine, RopeRenderer ropeRenderer)
        {
            _stateMachine = stateMachine;
            _ropeRenderer = ropeRenderer;
        }

        public void Enter()
        {
            
        }
    }
}