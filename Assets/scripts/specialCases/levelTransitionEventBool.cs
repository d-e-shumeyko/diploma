using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTransitionEventBool : MonoBehaviour
    
  

{
    [SerializeField] private GameObject transition;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void eventBool()
    {
        animator.SetBool("played", true);
    }
}
