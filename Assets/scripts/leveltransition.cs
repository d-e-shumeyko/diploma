using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltransition : MonoBehaviour
{
    //TODO FIX



    public int sceneBuildIndex;
    [SerializeField] private GameObject transitionAnim;
    private Animator animator;




    public void Update()
    {
        if (animator != null)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                //animator.SetBool("played", true);
                changeScene();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(transitionAnimation());

        }
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    private IEnumerator transitionAnimation()
    {
        animator = Instantiate(transitionAnim).GetComponent<Animator>();
        animator.SetBool("transition", true);
        
        
        yield return null;
    }
}
