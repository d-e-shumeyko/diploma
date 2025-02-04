using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mansionComputer : MonoBehaviour
{

    public bool inrange;
    [SerializeField] private GameObject panel;

    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            panel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(34, LoadSceneMode.Single);
            }
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
