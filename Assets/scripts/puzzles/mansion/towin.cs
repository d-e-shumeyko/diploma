using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towin : MonoBehaviour, Idatapersistence
{
    private int pointstowin;
    private int currentpoints;
    private bool sceneFin;
    //[SerializeField] private GameObject places;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        pointstowin = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentpoints >= pointstowin || sceneFin)
        {
            winScreen.SetActive(true);
            sceneFin = true;

        }
    }
    public void addpoints()
    {
        currentpoints++;
    }


    public void loadData(gameData data)
    {
        this.sceneFin = data.mansionFinished;

    }
    public void saveData(ref gameData data)
    {

        data.mansionFinished = this.sceneFin;
    }
}
