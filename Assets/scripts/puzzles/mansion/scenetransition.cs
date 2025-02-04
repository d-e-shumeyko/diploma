using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{

    public void sceneFinished() 
    {
        SceneManager.LoadScene(29, LoadSceneMode.Single);
    }
    public void sceneGoBack() 
    {
        SceneManager.LoadScene(22, LoadSceneMode.Single);
    }
}
