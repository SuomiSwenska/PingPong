using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField] private int _count;

    private GameCycleSystem _gameCycleSystem;
    private UISystem _uISystem;

    private void Awake()
    {
        _gameCycleSystem = FindObjectOfType<GameCycleSystem>();
        _uISystem = FindObjectOfType<UISystem>();
    }

    private void OnEnable()
    {
        _gameCycleSystem.OnFieldAbandoned += OnFieldAbandonedHandler;
    }

    private void OnDisable()
    {
        _gameCycleSystem.OnFieldAbandoned -= OnFieldAbandonedHandler;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.transform.GetComponent<Ball>();
        if (ball != null)
        {
            _count++;
            _gameCycleSystem.OnPlayerBallContact?.Invoke();
            _uISystem.OnCounterChanged?.Invoke(_count);
        }
    }

    private void OnFieldAbandonedHandler(Ball ball)
    {
        if (Vector3.Distance(transform.position, ball.transform.position) 
            < Vector3.Distance(_gameCycleSystem.aiPlatform.position, ball.transform.position))
        {
            _gameCycleSystem.OnPlayerLostBall?.Invoke(_count);
            _count = 0;
            _uISystem.OnCounterChanged?.Invoke(_count);
        }
    }
}
