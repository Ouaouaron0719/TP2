using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private Rigidbody2D rb; 
    private Animator animator;
    private Vector3 respawnPosition;
   
    private int fruitCount;
    [SerializeField] public TextMeshProUGUI fruitCounterText;

    [SerializeField] GameObject victoryUI;


    void OnTriggerEnter2D(Collider2D other)
    {

        Fruit fruit = other.gameObject.GetComponent<Fruit>();
        if (fruit != null)
        {
            CollectFruit(fruit);
        }
    }

    void UpdateFruitCounter()
    {
        fruitCounterText.text = "Fruits: " + fruitCount.ToString() + "/5";
    }
    internal void CollectFruit(Fruit fruit)
    {
        if (!fruit.isCollected)
        {
            fruit.Disappear(); 
            fruitCount++; 
            UpdateFruitCounter(); 

            
            if (fruitCount >= 5)
            {
                victoryUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    internal void Die() 
    {
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(FlashBeforeRespawn());
    }
    private IEnumerator FlashBeforeRespawn()//From GPT
    {
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;

        for (int i = 0; i < 6; i++)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.2f);
            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        RespawnPlayer();
    }
    private void RespawnPlayer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.transform.position = respawnPosition;
    }
    void Start()
    {
        respawnPosition = transform.position;   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        victoryUI.SetActive(false);
    }



    void Update()
    {
        
        float move = Input.GetAxis("Horizontal");

        
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        
        animator.SetFloat("Speed", Mathf.Abs(move));

        
        if (move != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(move) * Mathf.Abs(scale.x); 
            transform.localScale = scale;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Physics2D.gravity = new Vector2(0, Physics2D.gravity.y * -1);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
             
        }
    }

}
