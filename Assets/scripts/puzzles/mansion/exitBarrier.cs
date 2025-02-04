using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitBarrier : MonoBehaviour, Idatapersistence
{
    private bool puzzleSolved;
    [SerializeField] private GameObject barrier;
    private void Start()
    {
        if (puzzleSolved)
        {
            barrier.SetActive(false);
        }
    }

    public void loadData(gameData data)
    {
        this.puzzleSolved = data.mansionFinished;

    }
    public void saveData(ref gameData data)
    {

        
    }
}
