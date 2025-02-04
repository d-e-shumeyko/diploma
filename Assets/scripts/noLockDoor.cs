using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noLockDoor : MonoBehaviour
{
    public bool inrange;
    private bool soundPlayed;
    private Animator animator;
    [SerializeField] private AudioClip doorSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        soundPlayed = false;
    }
    void Update()
    {
        
            updateAnimator();
            playAudioClip();
       
       
    }

    private void playAudioClip()
    {
        if (!soundPlayed && inrange)
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
            soundPlayed = true;
        }
    }
    private void updateAnimator()
    {
        if (inrange)
        {
            animator.SetBool("inrange", true);
            
        }
        else
        {
            animator.SetBool("inrange", false);
            soundPlayed = false;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inrange = false;
        }
    }
}
