using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TMP_Text timerText;
    float timePassedInSeconds;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timePassedInSeconds += Time.deltaTime;
        timerText.text = $"Timer: {(int)timePassedInSeconds}s";
    }
}
