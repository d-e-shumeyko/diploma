using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wishingWell : MonoBehaviour, Idatapersistence
{
    [Header("Parameters")]
    [SerializeField] private GameObject cue;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject noCoinPanel;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    private int coinsCollected;



    private bool inRange = false;

    
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            cue.SetActive(true);
            if (inRange && inputManager.GetInstance().GetInteractPressed())
            {
                panel.SetActive(true);
            }
        }
        else 
        { 
            cue.SetActive(false); 
        }
    }
    public void backButton()
    {
        panel.SetActive(false );
     
    }

    public void wishButtonPressed()
    {
        if (coinsCollected <= 0) 
        {
            text1.SetActive(false);
            text2.SetActive(false);
        noCoinPanel.SetActive(true);
        }
        else
        {
            coinsCollected--;
            SceneManager.LoadScene(19, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
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
        this.coinsCollected = data.coins;

    }
    public void saveData(ref gameData data)
    {
        data.coins = this.coinsCollected;
    }
}
