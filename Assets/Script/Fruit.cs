using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isCollected = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
    public void Disappear()
    {
        if (!isCollected) 
        {
            isCollected = true;
            gameObject.SetActive(false);
        }
    }

    public void ResetFruit()
    {
        isCollected = false; 
        transform.position = initialPosition; 
        gameObject.SetActive(true); 
    }
}
