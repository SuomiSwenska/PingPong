using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void SetPauseState(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
    }
}
