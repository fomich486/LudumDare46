using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindState : StateBase
{
    private float nextUpdateTime;

    public override void EnterState(GameController _owner)
    {
        stateAdvice = UIController.Instance.Advices.GetRandomAdvice();
        base.EnterState(_owner);
    }
    public override void UpdateState(GameController _owner)
    {
        base.UpdateState(_owner);

        if (Time.time > nextUpdateTime)
        {
            _owner.rose.CheckWindDamage();
            nextUpdateTime = Time.time + GameController.Instance.GameDesigneData.wind_delay;
        }
    }

    protected override void SetNewState(GameController _owner)
    {
        _owner.stateMachine.ChangeState(new NormalState());
    }
}
