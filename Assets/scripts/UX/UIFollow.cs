using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    void Start()
    {
        this.transform.position = new Vector2(sprite.transform.position.x, sprite.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(sprite.transform.position.x, sprite.transform.position.y);
    }
}
