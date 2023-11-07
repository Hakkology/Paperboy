using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance ?? (_instance = new AudioManager());

    private Dictionary<string, AudioData.Sound> soundDictionary;
    private AudioMixerGroup commonMixerGroup;
    private List<AudioSource> audioSources = new List<AudioSource>();
    private GameObject soundGameObject;

    private AudioManager()
    {
        soundDictionary = new Dictionary<string, AudioData.Sound>();
        soundGameObject = new GameObject("Sound");
        Object.DontDestroyOnLoad(soundGameObject);
    }

    public void Initialize(AudioData audioData)
    {
        foreach (var sound in audioData.gameStateSounds)
        {
            soundDictionary[sound.name] = sound;
        }

        commonMixerGroup = audioData.commonMixerGroup;
        
        AddAudioSource();
    }

    private AudioSource AddAudioSource()
    {
        var newAudioSource = soundGameObject.AddComponent<AudioSource>();
        newAudioSource.outputAudioMixerGroup = commonMixerGroup;
        audioSources.Add(newAudioSource);
        return newAudioSource;
    }

    public void PlaySound(string name)
    {
        if (soundDictionary.TryGetValue(name, out AudioData.Sound sound))
        {
            if (!sound.loop)
            {
                
                AudioSource sourceToUse = audioSources.Find(source => !source.isPlaying) ?? AddAudioSource();
                sourceToUse.PlayOneShot(sound.clip);
            }
            else
            {
                
                AudioSource sourceToUse = audioSources.Find(source => source.clip == sound.clip && source.isPlaying);
                if (sourceToUse == null)
                {
                    sourceToUse = AddAudioSource();
                    sourceToUse.clip = sound.clip;
                    sourceToUse.loop = true;
                    sourceToUse.Play();
                }
            }
        }
        else
        {
            Debug.LogWarning("Sound name not found in dictionary: " + name);
        }
    }

    public void StopSound(string name)
    {
        if (soundDictionary.TryGetValue(name, out AudioData.Sound sound))
        {
            // Find all audio sources that are playing this clip
            var sourcesPlayingClip = audioSources.Where(source => source.clip == sound.clip && source.isPlaying).ToList();

            foreach (var src in sourcesPlayingClip)
            {
                src.Stop(); // Stop the audio source if it's playing the given clip
            }
        }
        else
        {
            Debug.LogWarning("Sound name not found in dictionary: " + name);
        }
    }

}
