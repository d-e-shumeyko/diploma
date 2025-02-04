using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessScript : MonoBehaviour, Idatapersistence
{
    [Header("Parameters")]
    [SerializeField] private GameObject darkness;
    [SerializeField] private GameObject darknessLess;
    [SerializeField] private string flaskID;
    [SerializeField] private string peroxideID;
    [SerializeField] private string diphenylOxalateID;
    private bool hasFlask;
    private bool hasPeroxide;
    private bool hasOxalate;
    private serializableDictionary<string, bool> keyItemsCollected;

    // Start is called before the first frame update
    void Start()
    {
       
        darkness.SetActive(true);
        foreach (KeyValuePair<string, bool> kvp in keyItemsCollected)
        {
            if (flaskID == kvp.Key)
            {
                hasFlask = true;
            }
            if (peroxideID == kvp.Key)
            {
                hasPeroxide = true;
            }
            if (diphenylOxalateID == kvp.Key)
            {
                hasOxalate = true;
            }
        }
        if (hasFlask && hasPeroxide && hasOxalate)
        {
            darkness.SetActive(false);
            darknessLess.SetActive(true);
        }
       

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void loadData(gameData data)
    {
        this.keyItemsCollected = data.keyItemInInventory;
        
    }
    public void saveData(ref gameData data)
    {


    }
}
