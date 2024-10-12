using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]public Vector2 spawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {//From GPT 13-26
            StartCoroutine(FreezeAndTeleport(other.gameObject));
        }
        
    }

    IEnumerator FreezeAndTeleport(GameObject player) 
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null) 
        {
            controller.enabled = false;
            yield return new WaitForSeconds(0.5f);
            player.transform.position = spawnPosition;
            controller.enabled = true;
        }
    }
}
