using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuaudio : MonoBehaviour
{
    public AudioClip ambientSound;
        void Start()
    {
        AudioSource.PlayClipAtPoint(ambientSound, transform.position);
    }

  
}
