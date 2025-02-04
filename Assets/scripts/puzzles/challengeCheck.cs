using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challengeCheck : MonoBehaviour, Idatapersistence

{
    [Header("challenge Settings")]
    [SerializeField] public int statIndex; // 0=strength; 1=mind; 2=social
    [SerializeField] public int difficultyRating; // 1-10 (1 is easy, 10 is hard)
    [SerializeField] private GameObject result;
    [SerializeField] private GameObject button;
    [SerializeField] private string iD;
    [SerializeField] private GameObject diceRoller;
    [SerializeField] private GameObject passPanel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] public Animator animator;
    private bool challengeTried;
    private bool challengePassed;
    int[] playersStats = new int[3];
    private int challengeValue;
    
    [ContextMenu("Generateguid for ID")]
    private void generateGuid()

    {
        iD = System.Guid.NewGuid().ToString();
    }


    
    void Start()
    {
       // animator = GetComponent<Animator>();


        if (!challengeTried)
        {
            result.SetActive(false);
            diceRoller.SetActive(false);
            passPanel.SetActive(false);
            failPanel.SetActive(false);
        }
        else 
        {
            button.SetActive(false);
            result.SetActive(true);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (challengeTried)
        {
            result.SetActive(true);
            button.SetActive(false);
        }
    }

    public void rollDice()
    {
        diceRoller.SetActive(true);

        StartCoroutine( diceRollAnimator());
        int challenge = 0;
        challenge =  difficultyRating - (playersStats[statIndex] + Random.Range(1, 11));
        if (challenge <=0)
        {
            challengePassed = true;
            challengeTried = true;
            
        }
        else
        {
            challengePassed = false;
            challengeTried = true;
            
        }
        Debug.Log("dice rolled" +  challenge);
        challengeValue = challenge;
    }
    public void saveData(ref gameData data)
    {
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
    public void loadData( gameData data)
    {
        data.challengesPassed.TryGetValue(iD, out challengePassed);
        data.challengeTried.TryGetValue(iD, out challengeTried);
        this.playersStats = data.stats;
    }

    public bool checkChallengePassded()
    {
        if (challengePassed)
        {
            return true;
        }
        return false;
    }
    

    public IEnumerator diceRollAnimator()
    {
        int[] rollNumbers = new int[38];

        for (int i = 0; i < 37; i++)
        {
            rollNumbers[i] = Random.Range(0,10);

        }
        foreach (int i in rollNumbers)
        {
            yield return new WaitForSeconds(0.02f);
            animator.SetFloat("float", i);
        }

        animator.SetFloat("float", challengeValue);
        if (challengePassed)
        {
            passPanel.SetActive(true);
            failPanel.SetActive(false);
        }
        else
        {
            passPanel.SetActive(false);
            failPanel.SetActive(true);
        }
    }


 
}
