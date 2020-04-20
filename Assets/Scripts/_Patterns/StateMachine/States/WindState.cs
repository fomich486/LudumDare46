using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindState : StateBase
{
    private float nextUpdateTime;

    public override void EnterState(GameController _owner)
    {
        stateAdvice = UIController.Instance.Advices.GetRandomAdvice();
        _owner.wind.gameObject.SetActive(true);
        AudioManager.Instance.windAudioSource.gameObject.SetActive(true);
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

    public override void ExitState(GameController _owner)
    {
        base.ExitState(_owner);
        _owner.wind.gameObject.SetActive(false);
        AudioManager.Instance.windAudioSource.gameObject.SetActive(false);
    }

    protected override void SetNewState(GameController _owner)
    {
        _owner.stateMachine.ChangeState(new NormalState());
    }
}
