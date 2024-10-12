using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomePage : MonoBehaviour
{
    public TMP_Text bestTimeText; 

    private void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        if (bestTime != Mathf.Infinity)
        {
            bestTimeText.text = $"Best Time: {FormatTime(bestTime)}";
        }
        else
        {
            bestTimeText.text = "Best Time: --:--"; 
        }
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

}
