using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameController : Singleton<GameController>
{
    public int BaobabsCount = 4;
    public GameDesigneData GameDesigneData;
    [HideInInspector]
    public StateMachine<GameController> stateMachine;

    public Asteroid asteroidPrefab;

    public RoseHealth rose;

    public bool isGameover = false;

    public ParticleSystem wind;
    
    private void Start()
    {
        rose = FindObjectOfType<RoseHealth>();
        
        stateMachine = new StateMachine<GameController>(this);
        stateMachine.ChangeState(new NormalState());
        
    }

    private void Update()
    {
        stateMachine?.currentState?.UpdateState(this);
        if (BaobabsCount >= 15)
        {
            UIController.Instance.GameOver("Baobabs tree destroyed your planet");
        }
    }

    public void SpawnAsteroid()
    {
        int rand = UnityEngine.Random.Range(1, 3);
        for (int i = 0; i < rand; i++)
        {
            Asteroid newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.Init();
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
