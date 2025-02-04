using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class inventoryItemData : ScriptableObject
{
    public string ID;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public bool isStackable;


}
    


