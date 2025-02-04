using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableobject : MonoBehaviour
{
    //method to give item unique(ish) ID
    [SerializeField] private string id;

    [ContextMenu("generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    
    // TODO finish making keys, items, etc.


}
