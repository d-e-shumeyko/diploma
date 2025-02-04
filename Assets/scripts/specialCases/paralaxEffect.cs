using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxEffect : MonoBehaviour
{
    [Header("parameters")]
    [SerializeField] Camera cam;
    [SerializeField] Transform followSprite;

    private Vector2 startPosition;
    private Vector2 CameraMovePosition => (Vector2)cam.transform.position - startPosition;
    private float startingZ;
    private float zDistanceFromTarget => transform.position.z - followSprite.transform.position.z;
    private float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    private float paralaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    
    void Start()
    {
        startPosition = transform.position;
        startingZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movePosition = startPosition + CameraMovePosition * paralaxFactor;
        transform.position = new Vector3(movePosition.x, movePosition.y, startingZ);
    }
}
