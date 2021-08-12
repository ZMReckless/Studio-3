using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Audio_FPS_Player : MonoBehaviourPunCallbacks
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
        if(!photonView.IsMine)
        {
            return;
        }

        fpsAudioSource.pitch = Random.Range(pitchMin, pitchMax);
        fpsAudioSource.PlayOneShot(footStep);

    }
}
