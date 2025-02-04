using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class moveButtons : MonoBehaviour
{
    [SerializeField]private GameObject correctform;
    private bool moving;
    private float startposx;
    private float startposy;
    private Vector3 resetposition;
    private bool finished;
    void Start()
    {
        resetposition = transform.localPosition;
    }

    void Update()
    {
        if (!finished)
        {
            if (moving)
            {
                Vector3 mousepos;
                mousepos = Input.mousePosition;
                mousepos = Camera.main.ScreenToWorldPoint(mousepos);
                gameObject.transform.localPosition = new Vector3(mousepos.x - startposx, mousepos.y - startposy, gameObject.transform.position.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            startposx = mousepos.x - transform.localPosition.x;
            startposy = mousepos.y - transform.localPosition.y;
            moving = true;
        }

    }
    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs((this.transform.localPosition.x - correctform.transform.localPosition.x)) <= 50.0f && Mathf.Abs((this.transform.localPosition.y - correctform.transform.localPosition.y)) <= 50.0f)
        {
            this.transform.position = new Vector3(correctform.transform.position.x, correctform.transform.position.y, correctform.transform.position.z);
            finished = true;
            GameObject.Find("pointsmanager").GetComponent<towin>().addpoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(resetposition.x, resetposition.y, resetposition.z);
        }
    }
}
