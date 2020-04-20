using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : StateBase
{
    private float nextUpdateTime;
    public override void EnterState(GameController _owner)
    {
        stateAdvice = UIController.Instance.Advices.GetRandomAdvice();
        base.EnterState(_owner);
    }
    
    protected override void SetNewState(GameController _owner)
    {
        int i = Random.Range(0, 2);
        if(i == 0)
            _owner.stateMachine.ChangeState(new AsteroidState() );
        else
        {
            _owner.stateMachine.ChangeState(new WindState());
        }
    }
    
    public override void UpdateState(GameController _owner)
    {
        base.UpdateState(_owner);
        
        if (Time.time > nextUpdateTime)
        {
            _owner.rose.CheckDomeDamage();
            nextUpdateTime = Time.time + GameController.Instance.GameDesigneData.wind_delay;
        }
      
    }
}
