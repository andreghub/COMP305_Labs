using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float runSpeed = 5.0f;
    public float jumpSpeed = 400.0f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    public Transform playerPosition;
    public Transform enemyAreaLimit;


    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator anim;
    private bool isGrounded;
    private float moveHorizontal;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        anim.SetFloat("vSpeed", rBody.velocity.y);

        if (isGrounded && playerPosition.position.x > enemyAreaLimit.position.x && this.transform.position.x > enemyAreaLimit.position.x)
        {
            moveHorizontal = (playerPosition.position.x > this.transform.position.x) ? 1 : -1;
            anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            rBody.velocity = new Vector2(moveHorizontal * runSpeed, rBody.velocity.y);

            if (rBody.velocity.x > 0.0f)
                sRend.flipX = false;
            else if (rBody.velocity.x < 0.0f)
                sRend.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object is a player, then do something
        if (other.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<CameraFollowWithBuffer>().GameOver();
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
