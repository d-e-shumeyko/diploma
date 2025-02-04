using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class dialogueTrigger : MonoBehaviour
{
    [Header("Cue")]
    [SerializeField] private GameObject cue;
    public bool playerInRange;
    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    private void Start()
    {
        playerInRange = false;
        cue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange && !dialogueManager.getInstance().dialogueIsPlaying)
        {
            cue.SetActive(true);
            if (inputManager.GetInstance().GetInteractPressed() || inputManager.GetInstance().GetJumpPressed()) 
            {
                dialogueManager.getInstance().EnterDialogueMode(inkJSON);
            }
            
        }
        else
        {
            cue.SetActive(false );
            
        }
       
    }
    

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange=true;
        }
    }




    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
