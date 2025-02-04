using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumpingCharacter : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float walkSpeed = 3f;
    //[SerializeField] private float airWalkSpeed = 2f;
    [SerializeField] private float jumpImpulse = 4f;
    Rigidbody2D rigidBody;
    private touchingGround touchingGround;
    public bool facingRight;
    public bool goingUp;
   


    public float currentMovement {  get
        {
            if (isMoving && !touchingGround.isWall)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    
    
    public Vector2 moveInput;
    private bool isMoving;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchingGround = GetComponent<touchingGround>();
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveInput.x * walkSpeed , rigidBody.velocity.y);


        
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        isMoving = moveInput != Vector2.zero;
        setFaceDir(moveInput);
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingGround.isGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpImpulse);
            goingUp = true;
        }
        if (touchingGround.isGround)
        {
            goingUp = false;
        }
    }

    public void setFaceDir(Vector2 moveInput)
    {
        if (moveInput.x >= 0 && !facingRight)
        {
            facingRight = true;
        }
        else if (moveInput.x < 0 && facingRight)
        {
            facingRight= false;
        }
    }
  
}
