using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupableItem : MonoBehaviour, Idatapersistence
{
    [SerializeField] private string iD;
    [SerializeField] private GameObject cue;
    [SerializeField] private bool isKeyItem = false;
    [SerializeField] private bool isCoin = false;
    [ContextMenu("Generateguid for ID")]
        private void generateGuid()
        
    {
        iD = System.Guid.NewGuid().ToString();
    }
    public bool inRange;
    public bool isCollected = false;
    public coinsScript cS;
    private inventoryManager inventoryManager;
    private bool _hasBeenCollected = false;
    public bool hasBeenCollected { get { return _hasBeenCollected; } private set { _hasBeenCollected = value; inventoryManager.updateInventory() ; } }


    void Start()
    {
       inventoryManager = GetComponent<inventoryManager>();
          
        if (isCollected)
        {
            gameObject.SetActive(false);
        }
    }

   
    void Update()
    {
        collectItem();

    }

    public void saveData(ref gameData data)
    {
        if (isCollected)
        {
            if (data.itemsCollected.ContainsKey(iD))
            {
                data.itemsCollected.Remove(iD);
            }
            data.itemsCollected.Add(iD, isCollected);
            if (isKeyItem)
            {
                if (data.keyItemInInventory.ContainsKey(iD))
                {
                    data.keyItemInInventory.Remove(iD);
                }
                data.keyItemInInventory.Add(iD, isCollected);
            }
        }
         
    }

    public void loadData(gameData data)
    {
        data.keyItemInInventory.TryGetValue(iD, out isCollected);
        data.itemsCollected.TryGetValue(iD, out isCollected);
        if (isCollected)
        {
            gameObject.SetActive(false);
        }

        
        
    }

    public void collectItem()
    {
        if (inRange)
        { cue.gameObject.SetActive(true);
           if(inRange && inputManager.GetInstance().GetInteractPressed())
            {
                isCollected = true;
                gameObject.SetActive(false);
                if (isCoin)
                {
                    cS.pickCoinUp();
                    updateInventory();
                }
                if (isKeyItem)
                {
                    updateInventory();
               
                }
            }
        }
        else
        {
            cue.gameObject.SetActive(false);
        }
    }


    public void updateInventory()
    {
        dataPersistenceManager.instance.saveGame();
        dataPersistenceManager.instance.loadGame();
    }
    public bool isCollect()
    {
        return isCollected;
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
