using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

    public AudioMixer musicMixer;

    AudioSource  musicSource;

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


    private IEnumerator increaseMusicSpeed(float speed)
    {
        StopCoroutine("decreaseMusicSpeed");
        float finalSpeed = musicSource.pitch + speed;
        while (musicSource.pitch <= finalSpeed)
        {
            musicSource.pitch += Time.deltaTime;
            if (musicSource.pitch > 3)
                musicSource.pitch = 3;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        musicSource.pitch = finalSpeed;
    }

    private IEnumerator DecreaseMusicSpeed(float speed)
    {
        StopCoroutine("decreaseMusicSpeed");
        float finalSpeed = musicSource.pitch - speed;
        while (musicSource.pitch >= finalSpeed)
        {
            musicSource.pitch -= Time.deltaTime;
            if (musicSource.pitch > 3)
                musicSource.pitch = 3;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        musicSource.pitch = finalSpeed;
    }


    private IEnumerator resetMusicSpeed()
    {
        StopCoroutine("increaseMusicSpeed");
        while (musicSource.pitch >= 1)
        {
            musicSource.pitch -= Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }
        musicSource.pitch = 1;
        yield break;
    }

    public void startIncreaseMusicSpeed(float speed)
    {
        StartCoroutine(increaseMusicSpeed(speed));
    }

    public void StartDecreaseMusicSpeed(float speed)
    {
        StartCoroutine(DecreaseMusicSpeed(speed));
    }

    public void RestartSpeed()
    {
        musicSource.pitch = 1;
    }
    public void startResetMusicSpeed()
    {
        StartCoroutine(resetMusicSpeed());
        StopCoroutine("increaseMusicSpeed");
    }

    public void SliderValue(float volume)
    {
        musicMixer.SetFloat("MusicVol", volume);
    }
}
