using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


// Ended up not using this script, but I'm not deleting it for now because I think I can still salvage it




public class playerStatManager : MonoBehaviour, Idatapersistence
{
    [Header("Menu Buttons")]
    
    [SerializeField] private Button jockClass;
    [SerializeField] private Button nerdClass;
    [SerializeField] private Button prepClass;
    // TODO [SerializeField] private Button customClass

    public int strength;
    public int mind;
     public int social;
    public string strengthN = "Strength";
    public string mindN = "Mind";
    public string socialN = "Social";
    private string statKey;
    public int statValue;
    public int[] statValues = new int[3];
    public List<string> statNames = new List<string>();


   public void statBuilder()
    {
        statNames.Add(strengthN);
        statNames.Add(mindN);
        statNames.Add(socialN);
        statValues[0] = strength;
        statValues[1] = mind;
        statValues[2] = social;
        
    }

    public void classJock()
    {
        strength = 1;
        mind = -1;
        social = 0;
        statBuilder();


       // SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void classNerd()
    {
        strength = 0;
        mind = 1;
        social = -1;
        statBuilder();
      //  SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    public void classPrep()
    {
        strength = -1;
        mind = 0;
        social = 1;
        statBuilder();
       // SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }


    //public void classCustom()
    //{

    //}

    public void saveData(ref gameData data)
    {
        //foreach (string st in statNames)
        //{
        //    int index = 0;
        //    {
        //        //if (data.playerStats.ContainsKey(st))
        //        //{
        //        //    data.playerStats.Remove(st);
        //        //}
        //        data.playerStats.Add(st, statValues[index]);
        //    }
        //    index++;
        //}
    }
    public void loadData(gameData data)
    {

    }
}
