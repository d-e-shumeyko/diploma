using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;
public class buttonTrackerPhys : MonoBehaviour, Idatapersistence
{
    [Header("Assets")]
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject lockpickButton;
    [SerializeField] private doorsandsign doorsandsign;
    [SerializeField] private GameObject cue;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string iD;

    //[Header("ink JSON")]
    //[SerializeField] private TextAsset inkJSON;

    private bool lockpickingTried;
    private Animator animator;
    private bool doorStatus;
    private bool lockStatus;
    private bool inRange;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    private bool challengePassed;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorsandsign.bunkStatus(doorStatus);
        doorsandsign.lockStatus(lockStatus);
        panel.SetActive(false);
        Debug.Log("button " + doorStatus);
        if (challengePassed)
        {
            doorStatus = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doorStatus)
        {
            animator.SetBool("doorUnlocked", true);

        }

        if (inRange && !doorStatus)
        {
            cue.SetActive(true);
            if (inRange && inputManager.GetInstance().GetInteractPressed())
            {
                panel.transform.position = new Vector2(sprite.transform.position.x, sprite.transform.position.y);
                panel.SetActive(true);


                if (lockStatus)
                {
                    lockpickButton.SetActive(false);
                }
            }

        }
        else
        {
            cue.SetActive(false);
        }

    }
    public void closepannel()
    {

        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    public void openPuzzle()
    {
        SceneManager.LoadScene(33, LoadSceneMode.Single);
    }

    public void rollLockpick()
    {
        doorsandsign.lockpickingTried = true;
        lockStatus = true;
        doorsandsign.lockStatus(lockStatus);
        Debug.Log("lock " + lockStatus);
    }
    public void loadData(gameData data)
    {
        this.doorStatus = data.doorPhysHab;
        data.challengesPassed.TryGetValue(iD, out challengePassed);
    }
    public void saveData(ref gameData data)
    {

    }


}