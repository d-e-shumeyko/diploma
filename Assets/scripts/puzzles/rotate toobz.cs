using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using Unity.Mathematics;
using JetBrains.Annotations;

public class rotatetoobz : MonoBehaviour
{
    public GameObject correctform;
    private bool mouseOver;
    private Vector3 randposition;
    private bool finished;
    public Vector3 startPosition;
    public Quaternion startRotation;

    void Start()
    {

        startRotation = transform.rotation;
        if (!GameObject.Find("datapersistencemanager").GetComponent<dataPersistenceManager>().doorPB())
        {
            randomPosition();
        }
        else
        {
            finished = true;

        }
    }

    void Update()
    {
        if (!finished)
        {
            mouseOver = IsTouchingMouse(gameObject);
            if (Input.GetMouseButtonDown(0) && mouseOver)
            {
                transform.rotation *= Quaternion.AngleAxis(90, Vector3.forward);
                correctPosition();
            }
        }
    }

    private void randomPosition()
    {
        transform.Rotate(0, 0, (90 /* UnityEngine.Random.Range(1, 4)*/));
    }
    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
    private void correctPosition()
    {
        if (math.abs(this.transform.rotation.x) == math.abs(correctform.transform.rotation.x) && math.abs(this.transform.rotation.y) == math.abs(correctform.transform.rotation.y) && math.abs(this.transform.rotation.z) == math.abs(correctform.transform.rotation.z))
        {

            finished = true;
            if (finished)
            {
                GameObject.Find("pointmanager").GetComponent<toWin>().addpoints();

            }

        }
        else
        {
            finished = false;

        }

    }
    public bool isFinished(bool bool1)
    {
        if (finished)
        {
            return true;
        }
        else { return false; }
    }


}
