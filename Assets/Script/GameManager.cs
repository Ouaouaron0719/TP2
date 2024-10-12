using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject celebrationUI;
    public TMP_Text totalTimeText;  
    public TMP_Text bestTimeText;   

    private float bestTime = Mathf.Infinity; 

    private void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);//From GPT
    }

    public void CompleteGame(float totalTime)//From GPT
    {

        celebrationUI.SetActive(true);

        totalTimeText.text = $"Total Time: {FormatTime(totalTime)}";


        if (totalTime < bestTime)
        {
            bestTime = totalTime;
            bestTimeText.text = $"Best Time: {FormatTime(bestTime)}";
            PlayerPrefs.SetFloat("BestTime", bestTime); 
        }
        else
        {
            bestTimeText.text = $"Best Time: {FormatTime(bestTime)}";
        }

        PlayerPrefs.Save();
    }


    private string FormatTime(float time)//From GPT
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        Timer timer = FindObjectOfType<Timer>();
        timer.ResetTimer();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Welcome");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
