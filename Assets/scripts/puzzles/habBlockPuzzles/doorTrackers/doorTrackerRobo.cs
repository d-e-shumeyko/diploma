using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class doorTrackerRobo : MonoBehaviour, Idatapersistence
{
    [SerializeField] private GameObject roof;
    [SerializeField] private GameObject door;
    [SerializeField] Collider2D m_collider;
    private Animator animatorDoor;
    [SerializeField] private doorsandsign doorsandsign;
    private bool status;
    private bool inRange;
    [SerializeField] private AudioClip doorSound;
    [SerializeField] private string iD;
    private bool challengePassed;
    void Start()
    {
        animatorDoor = GetComponent<Animator>();
        m_collider = GetComponent<Collider2D>();
        roof.SetActive(true);
        Debug.Log(status);
        if (challengePassed)
        {
            status = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (status)
        {

            animatorDoor.SetBool("doorunlocked", true);
            m_collider.enabled = false;
            roof.SetActive(false);
            if (inRange)
            {
                animatorDoor.SetBool("inrange", true);
                
            }
            else
            {
                animatorDoor.SetBool("inrange", false);
                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            if (status)
            {
                AudioSource.PlayClipAtPoint(doorSound, transform.position);
            }

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
        this.status = data.doorRoboHab;
        data.challengesPassed.TryGetValue(iD, out challengePassed);
    }
    public void saveData(ref gameData data)
    {

    }
}
