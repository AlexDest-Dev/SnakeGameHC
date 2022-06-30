using System;
using System.Collections.Generic;

namespace Player.States
{
    public class PlayerStateContainer
    {
        public event Action<IPlayerState> PlayerStateChanged;
        
        private IPlayerState _currentState;
        private Dictionary<Type, IPlayerState> _states;

        public IPlayerState CurrentState => _currentState;

        public PlayerStateContainer(IPlayerState[] states)
        {
            _states = new Dictionary<Type, IPlayerState>();
            foreach (var state in states)
            {
                Type stateType = state.GetType();
                _states[stateType] = state;
            }
        }

        public void ChangeState<T>() where T : IPlayerState
        {
            _currentState = _states[typeof(T)];
            PlayerStateChanged?.Invoke(_currentState);
        }
    }
}