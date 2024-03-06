using Rope.Infrastructure.CoroutineRunner;
using Rope.Infrastructure.States;
using Rope.Services.SceneLoading;
using Rope.Services.States;

namespace Rope.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; private set; }

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(AllServices.Container);
        }
    }
}