using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionTracker : MonoBehaviour, Idatapersistence
{
    [Header("Level Transitions")]
    [SerializeField] private GameObject[] toLabDimension;
    
    [SerializeField] private string[] ID;
    [SerializeField] private GameObject[] roof;
    private Dictionary<string, bool> dimensionPassed;


    void Start()
    {


            foreach (KeyValuePair<string, bool> kvp in dimensionPassed)
            {
            for (int i = 0; i< 3; i++) {
                if (ID[i] == kvp.Key)
                {
                    toLabDimension[i].SetActive(false);
                    roof[i].SetActive(false);
                }
                else
                {
                    continue;
                }
            }
            


        }
        
    }
    

    public void loadData(gameData data)
    {
        this.dimensionPassed = data.dimensionPassed;
    }
    public void saveData(ref gameData data)
    {

    }
}
