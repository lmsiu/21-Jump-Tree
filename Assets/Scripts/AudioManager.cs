using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public Sound[] musicSounds, sfxSounds;
	public AudioSource musicSource, sfxSource;


	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

	}

    private void Start()
    {
		PlayBGM("bgm");
    }

    public void PlayBGM(string name)
	{
		Sound s = Array.Find(musicSounds, item => item.name == name);
		musicSource.clip = s.clip;
		musicSource.Play();
	}

	public void PlaySFX(string name)
	{
		Sound s = Array.Find(sfxSounds, item => item.name == name);
		sfxSource.PlayOneShot(s.clip);
	}


	public void BGMVolume(float volume)
    {
		musicSource.volume = volume;
    }

	public void SFXVolume(float volume)
	{
		sfxSource.volume = volume;
	}
}
