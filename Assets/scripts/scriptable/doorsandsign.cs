using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create Door Tracker")]
public class doorsandsign : ScriptableObject
{

    [SerializeField] public bool doorToBunk;

    [SerializeField] public bool lockpickingTried;
   // [SerializeField] bool buttonToBunk { get; set; }
  
    public bool lockStatus(bool lockStatus)
    {
        lockStatus = lockpickingTried;
        return lockStatus;
    }
    public bool bunkStatus(bool bioStatus)
    {
        bioStatus = doorToBunk;
        return bioStatus;
    }

   
    public void bunkOpen()
    {
        doorToBunk = true;
        Debug.Log(doorToBunk);
    }

    public void lockPicked()
    {
       // lockpickingTried = true;
        
    }

}
