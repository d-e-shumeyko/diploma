using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airLockDoor : MonoBehaviour, Idatapersistence
{
    private Dictionary<string, bool> keyItemsCollected;
    private Animator Animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private AudioClip clip;
    private bool inRange;
    private bool status;
    private bool hasSpaceSuit = false;
    private bool hasToolBox = false;

    void Start()
    {
        Animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        checkInvCont();

    }

    // Update is called once per frame
    void Update()
    {
        if (status)
        {

            Animator.SetBool("doorunlocked", true);
            boxCollider.enabled = false;

            if (inRange)
            {
                Animator.SetBool("inrange", true);

            }
            else
            {
                Animator.SetBool("inrange", false);

            }
        }
    }

    public void loadData(gameData data)
    {
        this.keyItemsCollected = data.keyItemInInventory;
    }
    public void saveData(ref gameData data)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            if (status)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void checkInvCont()
    {
        

        foreach (KeyValuePair<string, bool> kvp in keyItemsCollected)
        {
            if ("spaceSuit" == kvp.Key)
            {
                hasToolBox = true;
            }
            if ("spaceSuit" == kvp.Key)
            {
                hasSpaceSuit = true;
            }
            if (hasSpaceSuit && hasToolBox)
            {
                status = true;
                break;
            }
        }

       

    }
}
