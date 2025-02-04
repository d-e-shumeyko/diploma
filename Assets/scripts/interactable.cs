using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactable : MonoBehaviour
{
    public UnityEvent interaction;
    public bool inrange;

    // Update is called once per frame
    void Update()
    {
        if(inrange)
        {
           // if (Input.GetMouseButtonDown(0))
           // {
                interaction.Invoke();
           // }
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
