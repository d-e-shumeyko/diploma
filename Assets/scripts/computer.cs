using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class computer : MonoBehaviour
{
    public bool isinrange;
    public bool solved;
    private Animator animator;
    [SerializeField] private AudioClip beep;
    [SerializeField] private GameObject target;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool istouching = IsTouchingMouse(target);
        if (isinrange && istouching && inputManager.GetInstance().GetInteractPressed())
        {
            SceneManager.LoadScene(7, LoadSceneMode.Single);
        } 
    }

    // Update is called once per frame
    public void turnOn()
    {

        if (!isinrange)
        {
            
            isinrange = true;
            animator.SetBool("in range", true);
            AudioSource.PlayClipAtPoint(beep, transform.position);
        }
    }
    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
    public bool inRange()
    {
        if (isinrange)
        {
            return true;
        }
        else return false;
    }
}
