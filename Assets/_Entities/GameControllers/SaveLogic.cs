using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLogic : MonoBehaviour
{
    private GameCycleSystem _gameCycleSystem;

    private void Awake()
    {
        _gameCycleSystem = FindObjectOfType<GameCycleSystem>();
    }

    private void Start()
    {
        _gameCycleSystem.OnBestResultChanged?.Invoke(GetBestResult());
    }

    private void OnEnable()
    {
        _gameCycleSystem.OnPlayerLostBall += TryToSaveBestResult;
    }

    private void OnDisable()
    {
        _gameCycleSystem.OnPlayerLostBall -= TryToSaveBestResult;
    }

    private int GetBestResult()
    {
        return PlayerPrefs.GetInt("BestResult");
    }

    private void TryToSaveBestResult(int result)
    {
        if (result > GetBestResult())
        {
            PlayerPrefs.SetInt("BestResult", result);
            _gameCycleSystem.OnBestResultChanged?.Invoke(result);
        }
    }
}
