using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    
    private Dictionary<Type, State> _states = new Dictionary<Type, State>();
    private State _currentState;
    public event Action<Type> OnStateChange;

    public Type GetCurrentStateType()
    {
        return _currentState.from.GetType();
    }
    public void RegisterState(IState state)
    {
        State newState = new State(state);
        _states.Add(state.GetType(), newState);

    }

    public void AddStateTransition(IState from,Transition transition)
    {
        _states[from.GetType()].AddTransition(transition);
    }

    public void SetCurrentState(IState to)
    {
        if(_currentState != null) _currentState.from.OnExit();
        _currentState = _states[to.GetType()];
        _currentState.from.OnEnter();
        OnStateChange?.Invoke(to.GetType());
    }

    public void UpdateState()
    {
        foreach (var transition in _currentState.StateTransitions)
        {
            if (transition.condition())
            {
                IState state = transition.toState;
                SetCurrentState(state);
                break;
            }
                
        }
        
        _currentState.from.OnUpdate();
    }
    
    public void ChangeState(IState from, Transition transition)
    {
        if(_currentState.from != from) return;

        if (transition.condition())
        {
            IState state = transition.toState;
            SetCurrentState(state);            
        }


    }
    
    public void ChangeStateFromAnyState(Transition transition)
    {
        if (transition.condition())
        {
            IState state = transition.toState;
            SetCurrentState(state);            
        }
    }

    public void LateUpdateState()
    {
        _currentState.from.OnLateUpdate();    
    }
}

public class State
{
    public IState from {get; private set;}
    private LinkedList<Transition> _transitions = new LinkedList<Transition>();
    public LinkedList<Transition>  StateTransitions => _transitions;
    
    public State(IState from)
    {
        this.from = from;
    }

    public void AddTransition(Transition transition)
    {
        _transitions.AddLast(transition);
    }
    
    
}


