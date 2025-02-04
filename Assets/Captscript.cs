using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Captscript : MonoBehaviour, Idatapersistence
{
    [SerializeField] private string dimID;
    [SerializeField] private GameObject panel;
    private Dictionary<string, bool> dimensionPassed;
    // Start is called before the first frame update
    void Start()
    {
        
        
        foreach(KeyValuePair<string, bool> kvp in dimensionPassed)
        {
            if (kvp.Key == dimID && kvp.Value == true)
            {
                panel.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadData(gameData data)
    {
        this.dimensionPassed = data.dimensionPassed;
    }
    public void saveData(ref gameData data)
    {

    }
}
