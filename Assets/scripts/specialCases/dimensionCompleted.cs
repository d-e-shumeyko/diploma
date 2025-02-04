using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimensionCompleted : MonoBehaviour, Idatapersistence
{
    [SerializeField] private string ID;
    [ContextMenu("Generateguid for ID")]
    private void generateGuid()

    {
        ID = System.Guid.NewGuid().ToString();
    }

    public bool inrange;
    

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inrange = true;
        }
    }
    public void loadData(gameData data)
    {
        data.dimensionPassed.TryGetValue(ID, out inrange);
    }
    public void saveData(ref gameData data)
    {

        if (data.dimensionPassed.ContainsKey(ID))
        {
            data.dimensionPassed.Remove(ID);
        }
        data.dimensionPassed.Add(ID, inrange);
    }
}


