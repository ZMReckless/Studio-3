using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{

    public string name;

    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    [Range(1f, 3f)]
    public float pitch;
    [Range(-1f, 1f)]
    public float panStereo;

    [HideInInspector]
    public AudioSource source;

}
