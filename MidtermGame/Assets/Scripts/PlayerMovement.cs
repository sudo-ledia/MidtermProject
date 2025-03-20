using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public float speed = 5f;
    public float jumpStrength = 10f;
    public GameObject player;
    public Rigidbody2D rb;

    public bool isGrounded;

    // Start is called before the first frame update\

    // private void Awake()
    // {
    //     // makes sure singleton player object doesnt destroy while loading
    //     if(Instance == null) {
    //         DontDestroyOnLoad(gameObject);
    //         Instance = this;
    //     }
    //     // makes sure there's onle one singleton player object
    //     else{
    //         Destroy(gameObject);
    //     }
    // }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveInput, 0f, 0f) * speed * Time.deltaTime;
        
        transform.position += movement;

        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            isGrounded = false;
        }

        else
        {
            return;
        }

   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {

            // Check if player's Y position is above the ground's Y position
            if (transform.position.y > other.bounds.center.y)
            {
                isGrounded = true;
            }
        }
        if(other.CompareTag("DeathBarrier"))
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
