using System;
using System.Collections.Generic;
using Rope.Infrastructure;
using Rope.Infrastructure.States;
using Rope.Services.SceneLoading;

namespace Rope.Services.States
{
    public class GameStateMachine : IService
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(AllServices services)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services.Single<ISceneLoader>()),
            };
        }

        public void RegisterState<TState>(TState state) where TState : class, IState
        {
            _states.Add(typeof(TState), state);
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
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