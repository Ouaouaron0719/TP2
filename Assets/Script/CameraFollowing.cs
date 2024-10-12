using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float followingSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y,-10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followingSpeed * Time.deltaTime);
        }
    }
}
