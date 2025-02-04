using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologue : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject textWithButton;

    public void switchGameObject()
    {
        text.SetActive(false);
        textWithButton.SetActive(true);

    }

    public void transitionToCharaCreation()
    {
        SceneManager.LoadScene(8, LoadSceneMode.Single);
    }
}
