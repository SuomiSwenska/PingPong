using System;
using UnityEngine;

public class GameCycleSystem : MonoBehaviour
{
    public Transform playerPlatform;
    public Transform aiPlatform;

    public Action<Ball> OnFieldAbandoned;
    public Action OnPlayerBallContact;
    public Action<int> OnPlayerLostBall;
    public Action<int> OnBestResultChanged;
}
