using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hole : MonoBehaviour
{
    public bool inrange;
    [SerializeField] private GameObject cue;

    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            cue.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(35, LoadSceneMode.Single);
            }
        }
        else
        {
            cue.SetActive(false);
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
