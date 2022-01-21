using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextKill : MonoBehaviour
{
    public Text start;
    public AudioClip startSound;

     AudioSource audioSource;
 
    void Start()
    {
        start.text = "Use the arrow keys or A & D to gather 3 cheese before time runs out!";

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        PlaySound(startSound);
        
        Destroy(gameObject, 2);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}