using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class bioHabPuzzle : MonoBehaviour, Idatapersistence
{
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject wrong;
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject tryAgain;
    [SerializeField] private GameObject rollSuccessful;
    [SerializeField] private doorsandsign scriptableObj;
    [SerializeField] private string id;
    private string iD;
    [SerializeField] private GameObject buttonPanel;
    private Dictionary<string, bool> challengePAssed;
    private bool gameWon;
    private bool challengePassed;
    
    void Start()
    {
        question.SetActive(true);
        wrong.SetActive(false);
        correct.SetActive(false);
        tryAgain.SetActive(false);
        buttonPanel.SetActive(true);
        rollSuccessful.SetActive(false);
        iD = id;

        foreach (KeyValuePair<string, bool> kvp in challengePAssed) 
        {
            if (id ==  kvp.Key && kvp.Value == true)
            {
                gameWon = kvp.Value;
                question.SetActive(false);
                buttonPanel.SetActive(false);
                rollSuccessful.SetActive(true);
            }
            else
            {
                continue;
            }
        }

       
   
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void wrongAnswer()
    {
        question.SetActive(false);
        wrong.SetActive(true);
        correct.SetActive(false);
        tryAgain.SetActive(true);
    }

    public void correctAnswer()
    {
        question.SetActive(false);
        wrong.SetActive(false);
        correct.SetActive(true);
        gameWon = true;
        challengePassed = true;
        setDoorToOpen();
    }
    public void tryQAgain()
    {
        question.SetActive(true);
        wrong.SetActive(false);
        correct.SetActive(false);
        tryAgain.SetActive(false);
    }

    private void setDoorToOpen()
    {
        //scriptableObj.bunkOpen();
        scriptableObj.doorToBunk = true;
    }
   
    public void closePuzzle()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void loadData(gameData data)
    {
        this.gameWon = data.doorBioHab;
        this.challengePAssed = data.challengesPassed;
       
        data.challengesPassed.TryGetValue(iD, out challengePassed);
    }
    public void saveData(ref gameData data)
    {
        data.doorBioHab = this.gameWon;
        if (data.challengesPassed.ContainsKey(iD))
        {
            data.challengesPassed.Remove(iD);
        }
        data.challengesPassed.Add(iD, challengePassed);

        if (data.challengeTried.ContainsKey(iD))
        {
            data.challengeTried.Remove(iD);
        }
        data.challengeTried.Add(iD, challengePassed);

    }
}
