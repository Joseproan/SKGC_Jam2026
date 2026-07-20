using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [HideInInspector] public string startMusicName;
    public static AudioManager Instance;

    public Music[] musicSounds;
    public SFXCategory[] sfxCategories;

    public AudioSource musicSource;

    public GameObject sfxSourcePrefab;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!string.IsNullOrEmpty(startMusicName))
        {
            PlayMusic(startMusicName);
        }
    }

    public void PlayMusic(string name)
    {
        Music s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music not found: " + name);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.volume = s.volume;
            musicSource.Play();
        }
    }

    public void PlaySFX(string category, string name)
    {
        SFXCategory cat = Array.Find(sfxCategories, c => c.categoryName == category);
        if (cat == null)
        {
            Debug.LogWarning($"SFX Category '{category}' not found");
            return;
        }

        SFX s = Array.Find(cat.sounds, x => x.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound '{name}' not found in category '{category}'");
        }
        else
        {
            var sfxSourceObj = Instantiate(sfxSourcePrefab);
            var sfxSource = sfxSourceObj.GetComponent<AudioSource>();
            var sfxClip = s.clips[Random.Range(0, s.clips.Length)];
            sfxSource.pitch = Random.Range(s.minPitch, s.maxPitch);
            sfxSource.PlayOneShot(sfxClip, s.volume);
            Destroy(sfxSourceObj, sfxClip.length);
        }
    }
    
    public AudioSource PlaySFXAndReturn(string category, string name, bool loop = false)
    {
        SFXCategory cat = Array.Find(sfxCategories, c => c.categoryName == category);
        if (cat == null)
        {
            Debug.LogWarning($"SFX Category '{category}' not found");
            return null;
        }

        SFX s = Array.Find(cat.sounds, x => x.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound '{name}' not found in category '{category}'");
        }
        else
        {
            var sfxSourceObj = Instantiate(sfxSourcePrefab);
            var sfxSource = sfxSourceObj.GetComponent<AudioSource>();
            var sfxClip = s.clips[Random.Range(0, s.clips.Length)];
            sfxSource.clip = sfxClip;
            sfxSource.loop = loop;
            sfxSource.Play();
            return sfxSource;
        }

        return null;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    /*public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }*/
}
