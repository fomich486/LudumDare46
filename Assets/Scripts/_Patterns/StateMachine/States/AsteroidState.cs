using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidState : StateBase
{
    private float asteroidSpawnDelay = 1f;
    private float nextAsteroidSpawnTime;
    
    public override void EnterState(GameController _owner)
    {
        stateAdvice = "Avoid asteroids";
        base.EnterState(_owner);
    }

    public override void UpdateState(GameController _owner)
    {
        base.UpdateState(_owner);
        if (Time.time > nextAsteroidSpawnTime)
        {
            _owner.SpawnAsteroid();
            asteroidSpawnDelay = Random.Range(0f, 2f);
            nextAsteroidSpawnTime = Time.time + asteroidSpawnDelay;
        }
    }

    protected override void SetNewState(GameController _owner)
    {
        _owner.stateMachine.ChangeState(new NormalState());
    }
}
