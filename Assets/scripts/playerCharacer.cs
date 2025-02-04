using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class playerCharacer : MonoBehaviour, Idatapersistence
{
    [Header("Start positions")]
    [SerializeField] public Vector2 defaultPosition;
    [SerializeField] public int[] entranceFromSceneIndex;
    [SerializeField] private GameObject[] entranceMarkers;

    [Header("Debug Options")]
    [SerializeField] private bool dontSaveLocation;

    public bool alternateSceneIndex;
    public int altSceneIndexValue;
    public float moveSpeed = 3f;
    public int dirFacing;
    public float collisionOffset = 0.02f;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public ContactFilter2D movementFilter;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public Vector2 playerPosition;
    public int sceneBuildIndex;
    public static dataPersistenceManager dataPersistenceManager;
    public Vector2 anotherPlayerPostion;
    public int[] statValues = new int[3];
    private bool _isMoving = false;
    public bool isMoving { get { return _isMoving; } private set { _isMoving = value; animator.SetBool("ismoving", value); } }
    //private bool _isfacingleft = false;
    //public bool isfacingleft { get { return _isfacingleft; } private set { _isfacingleft = value; animator.SetBool("isfacingleft", value); } }
    //private bool _isfacingright = false;
    //public bool isfacingright { get { return _isfacingright; } private set { _isfacingright = value; animator.SetBool("isfacingright", value); } }
    //private bool _isfacingup = false;
    //public bool isfacingup { get { return _isfacingup; } private set { _isfacingup = value; animator.SetBool("isfacingup", value); } }
    //private bool _isfacingdown = false;
    //public bool isfacingdown { get { return _isfacingdown; } private set { _isfacingdown = value; animator.SetBool("isfacingdown", value); } }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entrancePosition();
        alternateSceneIndex = false;
        

    }

    

    private void FixedUpdate()
    {
        
        if (dialogueManager.getInstance().dialogueIsPlaying)
        {
            return;
        }
     
        if (movementInput != Vector2.zero)
        {
            bool success = tryMove(movementInput);
            if (!success)
            {
                success = tryMove(new Vector2(movementInput.x, 0));
                if (!success)
                {
                    success = tryMove(new Vector2(0, movementInput.y));
                }
            }
            
        }
        
       
    }
    private void Update()
    {
        
        updateAnimator();
        playerPosition = new Vector2 (transform.position.x, transform.position.y);
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
           
    }

    private bool tryMove(Vector2 direction)
    {

        int count = rigidBody.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rigidBody.MovePosition(rigidBody.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    Vector2 moveInput = context.ReadValue<Vector2>();
    //    isfacingright = moveInput != Vector2.zero;

    //    setFacingDir(moveInput);
    //}

    //private void setFacingDir(Vector2 moveInput)
    //{
    //    if (moveInput.x > 0)
    //    {
    //        isfacingright = true;
           
    //    }
    //    else
    //    {
    //        isfacingright = false;
    //    }
        
        
    //    if (moveInput.y > 0)
    //    {
    //        isfacingup = true;
    //    }
    //    else
    //    {
    //        isfacingup = false;
    //    }
        
    //    if (moveInput.x < 0)
    //    {
    //        isfacingleft = true;
    //    }
    //    else
    //    {
    //        isfacingleft = false;
    //    } 
        
    //    if (moveInput.y < 0)
    //    {
    //        isfacingdown = true;
    //    }
    //    else
    //    {
    //        isfacingdown = false;
    //    }

    //}



    //public void playerPosistionacquiring() 
    //{
    //    anotherPlayerPostion = this.playerPosition;
    //}
    public Vector2 playerSpritePosition()
    {
        return transform.position;
    }
    public void loadData(gameData data)
    {
        this.playerPosition = data.playerPosition;
        //this.transform.position = data.playerPosition;
        this.sceneBuildIndex = data.sceneBuildIndex;
        this.statValues = data.stats;
        this.altSceneIndexValue = data.altSceneIndex;
        this.alternateSceneIndex = data.altSceneBool;
    }
    public void saveData(ref gameData data)
    {
        if (!dontSaveLocation)
        {
            data.playerPosition = this.transform.position;
        }
            data.altSceneIndex = this.altSceneIndexValue;
        data.altSceneBool = this.alternateSceneIndex;
            data.sceneBuildIndex = this.sceneBuildIndex;            
            data.stats = this.statValues;
      
    }

  
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    private void updateAnimator()
    {
        dirFacing = facingDirection(movementInput);
        animator.SetInteger("angle", dirFacing);
    }
    //change location on start to doorway
    private void entrancePosition()
    {
        int index = -1;


        if (entranceFromSceneIndex != null)
        {
            if (alternateSceneIndex)
            {
                for (int i = 0; i < entranceFromSceneIndex.Length; i++)
                {
                    if (entranceFromSceneIndex[i] == altSceneIndexValue)
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        index = -1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < entranceFromSceneIndex.Length; i++)
                {
                    if (entranceFromSceneIndex[i] == sceneBuildIndex)
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        index = -1;
                    }
                }
            }
        }
        
        if (index == -1)
        {
            this.transform.position = defaultPosition;
        }
        else
        {
            this.transform.position = entranceMarkers[index].transform.position;
        }
    }


    //TODO rework 
    public int facingDirection(Vector2 direction)
    {
        if (movementInput == Vector2.zero)
            return 0;



        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
        {
            return 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S))
        {
            return 2;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
        {
            return 3;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            return 4;
        }
        else
        {
            return 0;
        }


    //if (movementInput != Vector2.zero)
    //    {
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            return 1;
    //        }
    //        else if (Input.GetKey(KeyCode.S))
    //        {
    //            return 2;
    //        }
    //        else if (Input.GetKey(KeyCode.D))
    //        {
    //            return 3;
    //        }
    //        else if (Input.GetKey(KeyCode.A))
    //        {
    //            return 4;
    //        }
    //        else
    //        {
    //            return 0;
    //        }

    //    }
    //    else
    //    {
    //        return 0;
    //    }
    }

    public void setAltBool(bool value, int altSceneValue)
    {
        alternateSceneIndex = value;
        altSceneIndexValue = altSceneValue;
    }

}

