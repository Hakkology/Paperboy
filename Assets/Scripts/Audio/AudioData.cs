using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundList", menuName = "Audio/SoundList")]
public class AudioData : ScriptableObject
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public bool loop;
    }

    public Sound[] gameStateSounds;
    public AudioMixerGroup commonMixerGroup;
}