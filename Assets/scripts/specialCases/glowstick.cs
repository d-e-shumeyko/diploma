using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowstick : MonoBehaviour, Idatapersistence
{
    
   
    
    [SerializeField] public GameObject image;
    
    public bool glowsticks;

    
    

    // Start is called before the first frame update
    void Start()
    {
        if (glowsticks)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void loadData(gameData data)
    {
        this.glowsticks = data.hasAGlowstick;
    }
    public void saveData(ref gameData data)
    {
        

    }


}
