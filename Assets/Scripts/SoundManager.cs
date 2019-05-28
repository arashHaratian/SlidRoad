using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource gameOverCollision;
    public AudioSource movePlayer;
    public AudioSource  collisionSource;
    public AudioSource fallingCollision;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void CollisionPlay(float volume)
    {
        collisionSource.volume = volume;
        collisionSource.Play();
    }

    public void PlayFallingCollision(float volume)
    {
        print("play");
        fallingCollision.volume = volume;
        fallingCollision.Play();
    }
    
}
