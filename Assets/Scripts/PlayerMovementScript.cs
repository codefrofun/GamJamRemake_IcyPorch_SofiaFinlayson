using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;

    [SerializeField] public float boxPlayer = 1.6f;
    [SerializeField] public float playerSpeed = 4f;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] private bool isGrounded;
    private float moveDirection = 1f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

    }

    private void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayerOnX();
        HandleJump();
        HandleRestart();
    }


    // X for moving forward + jump
    void MovePlayerOnX()
    {
        if(Input.GetKey(KeyCode.X)) // Use get key not getkeydown for a continuation of movement
        {
            Debug.Log("Player has started moving!");
            float moveInput = moveDirection * playerSpeed;
            playerRigidbody.velocity = new Vector2(moveInput, playerRigidbody.velocity.y);
        }
    }
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Player Jumped!");
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Applies upward force
            isGrounded = false;
        }
    }



    /// <summary>
    /// Collision with walls so that player automatically turns, 
    /// does not go through walls, follows path. 
    /// (EVENTUALLY CODE THE APPEARING WALLS AND STONE WALLS THAT BREAK)
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveDirection = -moveDirection; // switches direction
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Checks if player is on the ground, giving the ability to jump without jumping on air
        }
    }

    /// <summary>
    /// Pressing "C" will freeze player (in place) on available magnet
    /// </summary>
    /// <param name="isMagnetActive"></param>
    void MagnetFreezePlayer(bool isMagnetActive)
    {
        if(isMagnetActive)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // R to restart level after player death
    void HandleRestart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    // Logic for level reset - CREATE SCENE MANAGER SCRIPT
    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name); // Relaod current scene CHANGE NAME ONCE APPLICABLE
    }
}
