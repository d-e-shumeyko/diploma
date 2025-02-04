using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class playerStatsPresets : MonoBehaviour, Idatapersistence
{
  public int[] stats = new int[3];
    public int strength;
    public int mind;
    public int social;

    public void statsBuilder()
    {
        stats[0] = strength;
        stats[1] = mind;
        stats[2] = social;
    }
    public void saveData(ref gameData data)
    {
       data.stats = this.stats;
    }
    public void loadData(gameData data)
    {
        this.stats = data.stats;
    }
   public void changeScene()
    {
        SceneManager.LoadSceneAsync(31, LoadSceneMode.Single);
    }
}
