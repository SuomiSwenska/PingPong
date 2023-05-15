using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISystem : MonoBehaviour
{
    public TextMeshProUGUI _textMeshProBestResult;
    public TextMeshProUGUI _textMeshProCounter;

    public Action<int> OnCounterChanged;
}
