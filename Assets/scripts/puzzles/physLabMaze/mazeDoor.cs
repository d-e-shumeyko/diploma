using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeDoor : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private GameObject theDoor;

    [SerializeField] private int activeSwitchCount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeSwitchCount >= 4)
        {
            theDoor.SetActive(false);
        }
    }

    public void switchActivated()
    {
        activeSwitchCount++;
    }
}
