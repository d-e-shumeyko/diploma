using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDebug : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private bool inrange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            player.transform.position = new Vector2(-2.537f, -0.140772f);
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
