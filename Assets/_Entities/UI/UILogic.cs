using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    private UISystem _uISystem;
    private GameCycleSystem _gameCycleSystem;

    private void Awake()
    {
        _uISystem = FindObjectOfType<UISystem>();
        _gameCycleSystem = FindObjectOfType<GameCycleSystem>();
    }

    private void OnEnable()
    {
        _uISystem.OnCounterChanged += OnCounterChangedHandler;
        _gameCycleSystem.OnBestResultChanged += OnBestResultChangedHandler;
    }

    private void OnDisable()
    {
        _uISystem.OnCounterChanged -= OnCounterChangedHandler;
        _gameCycleSystem.OnBestResultChanged -= OnBestResultChangedHandler;
    }

    private void OnCounterChangedHandler(int count)
    {
        _uISystem._textMeshProCounter.text = count.ToString();
    }

    private void OnBestResultChangedHandler(int count)
    {
        _uISystem._textMeshProBestResult.text = count.ToString();
    }
}
