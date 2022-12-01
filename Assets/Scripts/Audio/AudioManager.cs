using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    //[SerializeField] AudioSource swordSource;
    [SerializeField] List<AudioClip> sfxClips = new List<AudioClip>();

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SFXVolume";
    public const string AMBIENT_KEY = "AmbientVolume";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadVolume();
    }

    //public void SwordSFX()
    //{
    //    AudioClip swordClip = sfxClips[0];

    //    swordSource.PlayOneShot(swordClip);
    //}

    void LoadVolume() // Volume saved in VolumeSettings.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        float ambientVolume = PlayerPrefs.GetFloat(AMBIENT_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_AMBIENT, Mathf.Log10(ambientVolume) * 20);
    }
}
