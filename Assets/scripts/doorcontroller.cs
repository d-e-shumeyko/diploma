using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorcontroller : MonoBehaviour, Idatapersistence
{
    public bool doorUnlocked;
    public bool inRange;
    private Animator animator;
    public GameObject door;
    [SerializeField] private AudioClip doorSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (doorUnlocked == true)
        {

            door.SetActive(false);
        }

    }

    private void Update()
    {
        if (doorUnlocked == true)
        {
            
            door.SetActive(false);
        }
        updateAnimator();
    
    }
    private void updateAnimator()
    {
        animator.SetInteger("status", doorStatus());
        
       
    }

    private int doorStatus()
    {
        if (inRange && doorUnlocked)
        {
            return 2;
        }
        else if (doorUnlocked)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }



 
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    public void loadData(gameData data)
    {
        this.doorUnlocked = data.doorUnlocked;
    }
    public void saveData(ref gameData data)
    {

    }
}

