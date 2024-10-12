using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friut : MonoBehaviour
{
    public static int fruitCount = 0;
    public GameObject victoryText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fruitCount++;
            Destroy(gameObject);

            if (fruitCount == 5)
            {
                victoryText.SetActive(true);
            }
        }
    }
}
