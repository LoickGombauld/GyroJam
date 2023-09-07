using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] [Range(0,1)] public float volumeScale;


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
    }


    [Header("General Variables")]
    [SerializeField] private AudioSource _audioGlobalSource;

    [Header("UI Sounds Clips")]
    [SerializeField] public AudioClip _clickSound;
    [SerializeField] public AudioClip _hoverSound;


    private void Start()
    {
        InitializedAudioManager();
    }
    public void InitializedAudioManager()
    {
        volumeScale = PlayerPrefs.GetFloat("volumeScale");
    }


    public void PlaySound(AudioClip audioClip, float volume)
    {
        _audioGlobalSource.PlayOneShot(audioClip, volume);
    }


}
