using System;
using System.Collections.Generic;
using Rope.Infrastructure;
using Rope.Infrastructure.States;
using Rope.Services.SceneLoading;

namespace Rope.Services.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(AllServices services)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(services.Single<ISceneLoader>()),
            };
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }


        private TState ChangeState<TState>() where TState : class, IState
        {
            if (_activeState is IExitableState exitableState)
                exitableState.Exit();
      
            var state = GetState<TState>();
            _activeState = state;
      
            return state;
        }

        private TState GetState<TState>() where TState : class, IState => 
            _states[typeof(TState)] as TState;
    }
}