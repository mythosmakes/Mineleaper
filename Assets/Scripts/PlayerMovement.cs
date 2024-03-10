using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;

    public float input;
    public float speed;
    public Vector3 respawnPoint;
    public bool disabled = false;

    [Header("Jump")]
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    public float jumpTime;
    public float jumpTimeCounter;
    private bool isJumping;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public Sprite stand;
    public Sprite walkLeft;
    public Sprite walkRight;


    public void Start()
    {
        respawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        #region Directional Sprites
        if (input == 0)
        {
            spriteRenderer.sprite = stand;
        }
        else if (input < 0)
        {
            spriteRenderer.sprite = walkLeft;
        }
        else if (input > 0)
        {
            spriteRenderer.sprite = walkRight;
        }
        #endregion

        #region Jump
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey("space") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        #endregion
    }

    void FixedUpdate()
    {
        if(!disabled)
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
    }

    public void Checkpoint()
    {
        respawnPoint = transform.position;
    }
}
