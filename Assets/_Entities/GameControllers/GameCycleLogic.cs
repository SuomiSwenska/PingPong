using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycleLogic : MonoBehaviour
{
    private GameCycleSystem _gameCycleSystem;

    private void Awake()
    {
        _gameCycleSystem = FindObjectOfType<GameCycleSystem>();
    }

    private void OnEnable()
    {
        _gameCycleSystem.OnFieldAbandoned += OnFieldAbandonedHandler;
    }

    private void OnDisable()
    {
        _gameCycleSystem.OnFieldAbandoned -= OnFieldAbandonedHandler;
    }

    private void OnFieldAbandonedHandler(Ball ball)
    {
        ball.RestartBall();
    }
}
