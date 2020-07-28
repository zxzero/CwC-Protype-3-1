using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DeathMusic : MonoBehaviour
{
    private float startingPitch = 0.7f;
    private float deathPitch = 0.28f;
    AudioSource audioPitch;
    private PlayerController playerControllerScript;
    public AudioClip bgMusic;

    void Awake()
    {
        audioPitch = GetComponent<AudioSource>();
        audioPitch.clip = bgMusic;
        audioPitch.Play();
        audioPitch.playOnAwake = true;
        audioPitch.loop = true;
        audioPitch.pitch = startingPitch;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            audioPitch.pitch = deathPitch;
            Debug.Log("Changing pitch");
        }
    }

    /*void ChangePitch()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (playerControllerScript.gameOver == true)
        {
            audioPitch.pitch = deathPitch;
            Debug.Log("Changing pitch");
        }
        
    }*/
}
