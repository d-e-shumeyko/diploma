using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class serializableDictionary<Tkey, Tvalue>: Dictionary<Tkey, Tvalue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<Tkey> keyList = new List<Tkey>();
    [SerializeField] private List<Tvalue> valueList = new List<Tvalue>();


    public void OnBeforeSerialize()
    {
        keyList.Clear(); 
        valueList.Clear();
        foreach (KeyValuePair<Tkey, Tvalue> kvp in this)
        {
            keyList.Add(kvp.Key);
            valueList.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize() 
    { 
    this.Clear();

        if (keyList.Count != valueList.Count) 
        {
            Debug.LogError("amout of keys " + keyList.Count + " != " + "amount of values" + valueList.Count );
        }


        for (int i = 0;i < keyList.Count; i++)
        {
            this.Add(keyList[i], valueList[i]);
        }
    }


}
