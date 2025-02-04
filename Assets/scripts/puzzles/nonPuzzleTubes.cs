using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonPuzzleTubes : MonoBehaviour
{

    public GameObject spiteBox;
    private bool mouseOver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("datapersistencemanager").GetComponent<dataPersistenceManager>().doorPB())
        {
            randomPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("datapersistencemanager").GetComponent<dataPersistenceManager>().doorPB())
        {
            mouseOver = IsTouchingMouse(gameObject);
            if (Input.GetMouseButtonDown(0) && mouseOver)
            {
                transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);
            }
        }
    }

    private void randomPosition()
    {
        this.transform.Rotate(0, 0, (90 * UnityEngine.Random.Range(1, 4)));
    }
    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
}
