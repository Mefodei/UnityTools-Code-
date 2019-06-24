﻿namespace UniGreenModules.UniStateMachine.Runtime.Interfaces
{
    public interface IStateFactory<TStateType, TResult>
    {
        TResult Create(TStateType state);
    }
}