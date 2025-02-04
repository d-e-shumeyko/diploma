using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventDoor : MonoBehaviour, Idatapersistence
{
    [SerializeField] private string ID;
    [SerializeField] private GameObject cue;
    private Dictionary<string, bool> keyItemsCollected;
    public bool inRange;
    public bool isInteractable;
    private bool hasBeenOpened;
    // Start is called before the first frame update
    void Start()
    {
        if (hasBeenOpened)
        {
            gameObject.SetActive(false);
            return;
        }
        
        foreach (KeyValuePair<string, bool> keyValuePair in keyItemsCollected)
        {
            if (ID == keyValuePair.Key && keyValuePair.Value == true ) 
            { 
                isInteractable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && isInteractable)
        {
            cue.SetActive(true);
            if (inRange && isInteractable && inputManager.GetInstance().GetInteractPressed())
            {
                gameObject.SetActive(false);
                hasBeenOpened = true;
            }
        }
        else
        {
            cue.SetActive(false );
        }
    }

    public void loadData(gameData data)
    {
        this.keyItemsCollected = data.keyItemInInventory;
        this.hasBeenOpened = data.ventDoorOpen;
        
    }
    public void saveData(ref gameData data)
    {
        data.ventDoorOpen = this.hasBeenOpened;

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
}
