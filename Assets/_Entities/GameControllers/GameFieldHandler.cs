using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldHandler : MonoBehaviour
{
    private GameCycleSystem _gameCycleSystem;

    private void Awake()
    {
        _gameCycleSystem = FindObjectOfType<GameCycleSystem>();
    }

    private void OnTriggerExit(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball is Ball) _gameCycleSystem.OnFieldAbandoned.Invoke(ball);
    }
}
