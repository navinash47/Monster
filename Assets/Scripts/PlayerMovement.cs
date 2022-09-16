using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private float movementY;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private bool isOnAir;
    private String GROUND_TAG = "Ground";
    [SerializeField]
    private float minX, maxX;
    private String ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX)
        {
            if (transform.position.x >= maxX + 10)
            {
                transform.position = new Vector3(maxX + 10,transform.position.y,transform.position.z);
            }
        }
        if (transform.position.x < minX)
        {
            if (transform.position.x <= minX - 10)
            {
                transform.position = new Vector3(minX - 10, transform.position.y, transform.position.z);
            }
        }
        PlayerMoveKeyBoard();

        PlayerJump();
        AnimatePlayer();
        
        

    }
    void FixedUpdate()
    {
        
    }
    void AnimatePlayer()
    {

            anim.SetBool(JUMP_ANIMATION, false);
            if (movementX > 0)
            {
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = false;
            }
            else if (movementX < 0)
            {
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = true;
            }
            else
            {
                anim.SetBool(WALK_ANIMATION, false);
            }

    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f)*Time.deltaTime*moveForce;

    }
    void PlayerJump()
    {
        
        if (Input.GetButtonDown("Jump")&& !isOnAir)
        {
            isOnAir = true;
            myBody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isOnAir = false;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
