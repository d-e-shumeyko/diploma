using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointcounter : MonoBehaviour
{
    public GameObject toob_0;
  
    public bool bool_0;


    private void Start()
    {
        bool_0 = false;
    }
    public void Update()
    {
        
    }

    public void toobCounter()
    {
        bool_0 = true;
    }
    public void toobFalse()
    {
        bool_0 = false;
    }
}
