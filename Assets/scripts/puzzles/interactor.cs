using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

interface iinteractable
{
    public void interact();
}
public class interactor : MonoBehaviour
{
    public Transform interactorsource;
    public float interactrange;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0)) 
        {
            Ray r = new Ray(interactorsource.position, interactorsource.forward);
            if (Physics.Raycast(r, out RaycastHit hitinfo, interactrange))
            {
                if (hitinfo.collider.gameObject.TryGetComponent(out iinteractable interactobj))
                {
                    interactobj.interact();
                }
            }
        }
    }
}
