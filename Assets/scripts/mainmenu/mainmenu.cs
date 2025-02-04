using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class mainmenu : MonoBehaviour
{

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private int sceneBuildIndex;
    private gameData gameData;
    private dataHandler dataHandler;

    private void Awake()
    {
       
    }
    private void Start()
    {
        if (!dataPersistenceManager.instance.hasGameData())
        {
            continueGameButton.interactable = false;
        }
       
    }
    public void onNewGameClicked()
    {
        Debug.Log("new game");
        //create new game
        dataPersistenceManager.instance.newGame();

        SceneManager.LoadSceneAsync(37, LoadSceneMode.Single);
    }
      
    public void onLoadGameClicked()
    { 
       this.sceneBuildIndex = dataPersistenceManager.instance.sceneIndex();
        Debug.Log("load game, sceneindex = " + sceneBuildIndex);
        SceneManager.LoadSceneAsync(this.sceneBuildIndex, LoadSceneMode.Single);
    }
    private void disableMenuButtons()
    {
    newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
  public void gettingScene()
    {
        
    }
}
