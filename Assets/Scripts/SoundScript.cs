using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip winSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // Draws sound effect from resources folder. (NAME FOLDER "Resources"!!)
        winSound = Resources.Load<AudioClip>("Cyberpunk Moonlight Sonata");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Cyberpunk Moonlight Sonata":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}

