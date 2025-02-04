using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class gameData
{
    public Vector2 playerPosition;
    public int sceneBuildIndex;
    public int altSceneIndex;
    public bool altSceneBool;
    public bool doorUnlocked;
    public serializableDictionary<string, bool> itemsCollected;
    public serializableDictionary<string, bool> keyItemInInventory;
    public serializableDictionary<string, bool> challengesPassed;
    public serializableDictionary<string, bool> challengeTried;
    public serializableDictionary<string, bool> dimensionPassed;
    // public serializableDictionary<string, int> playerStats;
    public int[] stats;
    public bool doorBioHab;
    public bool doorRoboHab;
    public bool doorPhysHab;
    public int coins;
    public bool ventDoorOpen;
    public bool hasAGlowstick;
    public bool mansionFinished;
    


    public gameData()
    {
        this.playerPosition = Vector2.zero;
        this.sceneBuildIndex = 0;
        this.doorUnlocked = false;
        this.itemsCollected = new serializableDictionary<string, bool>();
        this.keyItemInInventory = new serializableDictionary<string, bool>();
        this.doorUnlocked = false;
       // this.playerStats = new serializableDictionary<string, int>();
        this.stats = new int[3];
        this.challengesPassed = new serializableDictionary<string, bool>();
        this.challengeTried = new serializableDictionary<string, bool>();
        this.doorBioHab = false;
        this.coins = 0;
        this.ventDoorOpen = false;
        this.altSceneIndex = 0;
        this.altSceneBool = false;
        this.dimensionPassed = new serializableDictionary<string, bool>();
        this.doorRoboHab = false; ;
        this.doorPhysHab = false;
        this.hasAGlowstick = false;
        this.mansionFinished = false;
    }

}
