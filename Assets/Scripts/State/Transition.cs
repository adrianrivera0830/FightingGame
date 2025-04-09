using System;
using UnityEngine;

public class Transition
{
    public IState toState;
    public Func<bool> condition;
    
    public Transition(IState to, Func<bool> condition)
    {
        toState = to;
        this.condition = condition;
    }
}
