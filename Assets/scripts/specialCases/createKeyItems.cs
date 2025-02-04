using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createKeyItems : MonoBehaviour, Idatapersistence
    {
    private serializableDictionary<string, bool> keyItems;
    // Start is called before the first frame update
    void Start()
    {
        keyItems.Add("flask", false);
        keyItems.Add("oxalate", false);
        keyItems.Add("peroxide", false);
        keyItems.Add("f9c2f078-9f38-4807-b8ca-9a392c611d5c", false);
        keyItems.Add("spaceSuit", false) ;
        keyItems.Add("tools", false);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadData(gameData data)
    {
        this.keyItems = data.keyItemInInventory;
    }
    public void saveData(ref gameData data)
    {
        data.keyItemInInventory = this.keyItems;



        
            
        }
    }

