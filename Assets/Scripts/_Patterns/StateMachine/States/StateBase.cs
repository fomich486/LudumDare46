using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public abstract class StateBase : State<GameController>
{
    protected float stateDuration;
    protected float changeStateTime;
    protected string stateAdvice;

    public override void EnterState(GameController _owner)
    {
        stateDuration = Random.Range(20f,30f);
        changeStateTime = Time.time + stateDuration;
        UIController.ChangeStateAdvice(stateAdvice);
    }

    public override void ExitState(GameController _owner)
    {
        
    }

    public override void UpdateState(GameController _owner)
    {
        if(Time.time > changeStateTime)
            SetNewState(_owner);
    }

    protected virtual void SetNewState(GameController _owner)
    {
        
    }
}
