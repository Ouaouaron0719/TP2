using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isCollected = false; 

    public void Disappear()
    {
        if (!isCollected) 
        {
            isCollected = true; 
            Destroy(gameObject); 
        }
    }
}
