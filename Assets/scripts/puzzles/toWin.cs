using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toWin : MonoBehaviour, Idatapersistence
{

    public bool doorUnlocked =false;
    public int pointstowin;
    public int currentpoints;
    public GameObject toob;
    public static dataPersistenceManager dataPersistenceManager;
    

    void Start()
    {
        pointstowin = toob.transform.childCount;
        if (GameObject.Find("datapersistencemanager").GetComponent<dataPersistenceManager>().doorPB() == true || GameObject.Find("challengeManager").GetComponent<challengeCheck>().checkChallengePassded() == true)
        {
            this.doorUnlocked = true;
            currentpoints = pointstowin;
        }
    }


    void Update()
    {
        if (currentpoints >= pointstowin || GameObject.Find("challengeManager").GetComponent<challengeCheck>().checkChallengePassded() == true)
        {
            
            transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("datapersistencemanager").GetComponent<dataPersistenceManager>().doorPB();
            doorUnlocked =true;

        }
        doorBool(doorUnlocked);
    }

    public void loadData(gameData data)
    {
        this.doorUnlocked = data.doorUnlocked;
    }
    public void saveData(ref gameData data)
    {
        data.doorUnlocked= this.doorUnlocked;
    }
    public bool doorBool(bool doorBool)
    {
        if (doorBool)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void addpoints()
    {
        currentpoints++;
    }
    public void subtractPoints()
    {
        currentpoints--;
    }
    
    }
    

