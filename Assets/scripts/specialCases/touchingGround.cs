using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchingGround : MonoBehaviour
{
    [SerializeField] private ContactFilter2D castFilter;
    [SerializeField] private float groundDistance = 0.05f;
    [SerializeField] private float wallCheckDist = 0.2f;
    [SerializeField] private float ceilingCheckDist = 0.05f;
    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D touchingCollider;
    private RaycastHit2D[] groundHit = new RaycastHit2D[5];
    private RaycastHit2D[] wallHits = new RaycastHit2D[5];
    private RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    private jumpingCharacter jC;

    private bool up;
    private Vector2 wallCheckDir => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;


    private bool _isGrounded;
    public bool isGround {  get { return _isGrounded; }  private set { _isGrounded = value; } }   

    private bool _isWall;
    public bool isWall { get { return _isWall; } private set { _isWall = value; } }
   
    private bool _isCeiling;
    public bool isCeiling { get { return _isCeiling; } private set { _isCeiling = value; } }
   

    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jC = GetComponent<jumpingCharacter>();
    }

  
    private void FixedUpdate()
    {
        
       isGround = touchingCollider.Cast(Vector2.down, castFilter, groundHit, groundDistance) > 0;
        isWall = touchingCollider.Cast(wallCheckDir, castFilter, wallHits, wallCheckDist) > 0;
        isCeiling = touchingCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingCheckDist) > 0;

        up = jC.goingUp;
        if (up)
        {
            animator.SetBool("inAir", true);
            if (rb.velocity.x > 0)
            {
                animator.SetInteger("dir", 3);
            }
            else if (rb.velocity.x < 0)
            {
                animator.SetInteger("dir", 4);
            }
            else
            {
                animator.SetBool("inAir", false);
            }

        }
       

        if (rb.velocity != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            if (jC.facingRight)
            {
                animator.SetInteger("dir", 1);
            }
            else if (!jC.facingRight)
            {
                animator.SetInteger("dir", 2);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        
        }

       

    }




