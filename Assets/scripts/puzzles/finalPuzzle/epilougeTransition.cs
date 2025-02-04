using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class epilougeTransition : MonoBehaviour
{
public void transitionToEpilouge()
    {
        SceneManager.LoadScene(36, LoadSceneMode.Single);
    }
}
