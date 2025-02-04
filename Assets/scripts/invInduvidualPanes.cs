using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invInduvidualPanes : MonoBehaviour, Idatapersistence
{
    [SerializeField] private BoxCollider2D colliderText;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject panel;
    [SerializeField] public GameObject image;
    [SerializeField] public string id;
    private serializableDictionary<string, bool> keyItemsCollected;
    private bool mouseOver;

    

    // Start is called before the first frame update
    void Start()
    {
        colliderText = GetComponent<BoxCollider2D>();
        image.SetActive(false);
        inventoryUdpate();
    }

    // Update is called once per frame
    void Update()
    {
        
        {
            mouseOver = IsTouchingMouse(panel);
            if (mouseOver)
            {
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }
        }
    }

    public void loadData(gameData data)
    {
        this.keyItemsCollected = data.keyItemInInventory;
    
    }
    public void saveData(ref gameData data)
    {


    }
    private void inventoryUdpate()
    {
        foreach (KeyValuePair<string, bool> kvp in keyItemsCollected)
        {
            
           if (id == kvp.Key && kvp.Value == true)
            {
                if(kvp.Key == null)
                {
                    continue;
                }
                image.SetActive(true);

                panel.SetActive(true);
                
            }
            
          
        }
    }

    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
}
