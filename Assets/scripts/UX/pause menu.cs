using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pausemenu : MonoBehaviour 
{


    // TODO fix later


    [Header("Interface Objects")]
    [SerializeField] private GameObject panelMain;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject pausebutton;
    
    //realized i don't need these, bur am keeping them to make it easier to keep track of buttons
    /*
    
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private GameObject loadButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject backButton;
    */

    public bool panelMainOpen;
    public bool panelOptionsOpen;
    public bool gameIspaused;
    public bool pauseCalled;
    private bool mouseOver;
    //private static pausemenu instance;

    //private void Awake()
    //{

    //    if (instance != null)
    //    {
    //        Debug.LogWarning(">1 instance");
    //    }
    //    instance = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        panelMain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        mouseOver = IsTouchingMouse(pausebutton);
        if (Input.GetMouseButtonDown(0) && mouseOver)
        {
            pauseGame();
        }

    }

    public void manualSave()
    {
        dataPersistenceManager.instance.saveGame();
    }
    public void manualLoad()
    {
        dataPersistenceManager.instance.loadGame();
    }
    public void manualQuit()
    {
        Application.Quit();
    }
    public void manualResme()
    {
        unpauseGame();   
    }
    public void openOptions()
    {
        if (panelMainOpen && !panelOptionsOpen)
        {
            panelOptions.SetActive(true);
            panelMain.SetActive(false);
            panelOptionsOpen = true;
        }
    }

    public void backFromOptions()
    {
        panelOptions.SetActive(false );
        panelMain.SetActive(true);
        panelMainOpen = true;
        panelOptionsOpen = false;
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        panelMainOpen = true;
        panelOptionsOpen = false;
        panelMain.SetActive(true);
        pausebutton.SetActive(false);

    }
    public void unpauseGame()
    {
        Time.timeScale = 1;
        panelMainOpen = false;
        panelOptionsOpen = false;
        panelMain.SetActive(false);
        panelOptions.SetActive(false);
        pausebutton.SetActive(true);
    }

    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
}
