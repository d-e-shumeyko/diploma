using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class dataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializwDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncription;

    private dataHandler dataHandler;
    public static dataPersistenceManager instance { get; private set; }
    private gameData gameData;
    private List<Idatapersistence> dataPersistenceObjects;
    public int prevScene;
    public bool doorPC;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void Awake()
    {
       if (instance != null)
        {
            Debug.Log("data persistance manager >1 in scene, new instance destroyed");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new dataHandler(Application.persistentDataPath, fileName, useEncription);
        prevScene = 1;
    }

    public void newGame()
    {
        this.gameData = new gameData();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = findAllDataPersistenceObjects();
        loadGame();
        //Debug.Log(Application.persistentDataPath);
    }

    public void OnSceneUnloaded(Scene scene)
    {
        saveGame();
        prevScene = gameData.sceneBuildIndex;
    }

    public void saveGame()
    {
        foreach (Idatapersistence dataPersistenceObjs in dataPersistenceObjects)
        {
            dataPersistenceObjs.saveData(ref gameData);
        }
        dataHandler.save(gameData); 
    }

    public void loadGame()
    {

        this.gameData = dataHandler.load();

        if (this.gameData == null && initializwDataIfNull)
        {
            newGame();
        }


        if (this.gameData == null)
        {
            Debug.Log("no game data found");
            return;
        }

        foreach (Idatapersistence dataPersistenceObjs in dataPersistenceObjects)
        {
            dataPersistenceObjs.loadData(gameData);
        }
        Debug.Log("position = " + gameData.playerPosition);
    }
    private void OnApplicationQuit()
    {
        saveGame();
    }

    private List<Idatapersistence> findAllDataPersistenceObjects()
    {
        IEnumerable<Idatapersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<Idatapersistence>();
        return new List<Idatapersistence>(dataPersistenceObjects);
    }
    public bool hasGameData()
    {
        return gameData != null;
    }
    public int sceneIndex()
    {
        return gameData.sceneBuildIndex;
    }
    public bool doorPB()
    {
        if (doorPC == true)
        {
            return doorPC;
        }
        else
        { return false; }
    }
}
