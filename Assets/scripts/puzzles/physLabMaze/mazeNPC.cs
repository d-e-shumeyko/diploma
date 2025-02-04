using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeNPC : MonoBehaviour
{
    public bool inrange;
    [SerializeField] private GameObject panelDoorLocked;
    [SerializeField] private GameObject panelDoorUnlocked;
    [SerializeField] private GameObject door;

    private GameObject panel;

    // Update is called once per frame
    void Update()
    {
        if (door.activeSelf)
        {
            panel = panelDoorLocked;
        }
        else
        {
            panel = panelDoorUnlocked;
        }
        
        if (inrange)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
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
