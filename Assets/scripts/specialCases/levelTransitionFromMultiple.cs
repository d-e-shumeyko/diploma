using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransitionFromMultiple : MonoBehaviour
{
    [SerializeField] private int alternateSceneIndex;
    [SerializeField] private bool makeAltscene;
    [SerializeField] private playerCharacer pc;
    private bool _isAltScene;
    public bool isAltScene { get { return _isAltScene; } set { _isAltScene = value; pc.setAltBool(true, alternateSceneIndex) ; } } 
                
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            pc.setAltBool(true, alternateSceneIndex);


        }
    }
}
