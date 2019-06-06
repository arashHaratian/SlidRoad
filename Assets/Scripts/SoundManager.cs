using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource gameOverCollision;
//    public AudioSource gameOverFalling;
    public AudioSource getGreen;
    public AudioSource getRed;
    public AudioSource movePlayer;
    public AudioSource  collisionSource;
    public AudioSource fallingCollision;
    public AudioMixer masterMixer;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        movePlayer.volume = 0;
        movePlayer.Play();
    }

    public void Reset()
    {
        movePlayer.volume = 0;
    }

    public void GameOverCollision(float volume)
    {
        gameOverCollision.volume = volume;
        gameOverCollision.Play();
    }
    public void CollisionPlay(float volume)
    {
        collisionSource.volume = volume;
        collisionSource.Play();
    }

    public void PlayFallingCollision(float volume)
    {
        fallingCollision.volume = volume;
        fallingCollision.Play();
    }

    public void PlayGetGreen(float volume)
    {
        getGreen.volume = volume;
        getGreen.Play();
    }

    public void PlayGetRed(float volume)
    {
        getRed.volume = volume;
        getRed.Play();
    }

    public void ChangeVolumeMovement(float volume)
    {
        movePlayer.volume = volume;
    }

    public void Mute(bool stateOfVol)
    {
        if(!stateOfVol)
            masterMixer.SetFloat("SFXVol", -80);
        else
            masterMixer.SetFloat("SFXVol", 0);

    }

    //    public void PlayGameOverFalling(float volume)
    //    {
    //        gameOverFalling.volume = volume;
    //        gameOverFalling.Play();
    //    }
}
