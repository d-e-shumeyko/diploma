using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class inventoryManager : MonoBehaviour, Idatapersistence
{
    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject buttonOn;
    [SerializeField] private GameObject buttonOff;
    //[SerializeField] private GameObject[] slots;
    [SerializeField] private TextMeshProUGUI coincounter;
    private serializableDictionary<string, bool> keyItemsCollected;
    private int coins;
    public bool hasGlowstick;
    

    private void Awake()
    {
        //foreach (var slot in slots)
        //{
        //    slot.SetActive(true);
        //}
        
    }

    void Start()
    {
      
        inventoryPanel.SetActive(false);
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
       

        updateInventory();
       glowstickFunk();
        
    }

    
  
    void Update()
    {
       
    }

    public void loadData(gameData data)
    {
        this.keyItemsCollected = data.keyItemInInventory;
        this.coins = data.coins;    
    }
    public void saveData(ref gameData data)
    {
       data.hasAGlowstick = this.hasGlowstick;

    }
    public void updateInventory()
    {
        coincounter.text = "Coins: " + coins;
      
    }

  

    public void activatePanel()
    {
        inventoryPanel.SetActive(true);
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
    }
    public void deactivatePanel()
    {
        inventoryPanel.SetActive(false);
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
    }

    public void glowstickFunk()
    {
        bool hasFlask = false;
        bool hasPeroxide = false;
        bool hasOxalate = false;

        foreach (KeyValuePair<string, bool> kvp in keyItemsCollected)
        {
            if ("flask" == kvp.Key)
            {
                hasFlask = true;
            }
            if ("peroxide" == kvp.Key)
            {
                hasPeroxide = true;
            }
            if ("oxalate" == kvp.Key)
            {
                hasOxalate = true;
            }
        }


        if (hasFlask && hasPeroxide && hasOxalate)
        {
            hasGlowstick = true;
        }

    }

}
