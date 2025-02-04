using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMoveScript : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private float offsetX ;
    [SerializeField] private float offsetY ;
    void Start()
    {
        buttonOffset();
    }

    // Update is called once per frame
    void Update()
    {
        buttonOffset();
    }

    public void buttonOffset()
    {
        this.transform.position = new Vector2 (playerSprite.transform.position.x+offsetX + 3, playerSprite.transform.position.y + offsetY + 2);
    }
}
