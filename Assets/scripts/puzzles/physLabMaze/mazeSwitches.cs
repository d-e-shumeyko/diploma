using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeSwitches : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private GameObject mazeSwitch;
    [SerializeField] private GameObject sign;

    private bool isActivated;
    private Animator animator;
    private bool switchNotFlipped;
    private mazeDoor mazeDoor;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        switchNotFlipped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            animator.SetBool("isActivated", true);

            sign.SetActive(true);
            if (switchNotFlipped)
            {
                mazeDoor.switchActivated();
                switchNotFlipped = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }
}
