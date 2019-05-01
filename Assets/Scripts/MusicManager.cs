using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

    public AudioMixer musicMixer;

    AudioSource musicSource;

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
        musicSource = GetComponent<AudioSource>();
    }

    public IEnumerator gameOVerEffect()
    {
        while (musicSource.pitch > 0 && GameManager.instance.GameOver)
        {
            musicSource.pitch -= 0.07f;
            if (musicSource.pitch < 0)
                musicSource.pitch = 0;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public void StartMusic()
    { 
        musicSource.enabled = false;
        musicSource.pitch = 1;
        musicSource.enabled = true;
        musicSource.Play();
    }

    public void increaseMusicSpeed(float speed)
    {
        musicSource.pitch *= speed;
        if (musicSource.pitch > 3)
            musicSource.pitch = 3;
    }

    public void SliderValue(float volume)
    {
        musicMixer.SetFloat("MusicVol", volume);
    }
}
