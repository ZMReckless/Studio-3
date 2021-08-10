using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_FPS_Player : MonoBehaviour
{
    public AudioClip footStep;
    public AudioSource fpsAudioSource;



    public float pitchMin;
    public float pitchMax;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ________PlayFootStep()
    {
        fpsAudioSource.pitch = Random.Range(pitchMin, pitchMax);
        fpsAudioSource.PlayOneShot(footStep);

    }
}
