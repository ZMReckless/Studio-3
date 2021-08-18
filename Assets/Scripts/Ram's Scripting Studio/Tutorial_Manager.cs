using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour
{
    public VideoClip[] tutorialClips;
    private int tutorialClipIndex;
    private VideoPlayer VP;

    public GameObject[] tutorialTitles;
    public GameObject[] tutorialArrows; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<VideoPlayer>();
        VP.clip = tutorialClips[0];
       
    }

    public void ChangeClip()
    {
        tutorialClipIndex++;

        if(tutorialClipIndex >= tutorialClips.Length)
        {
            tutorialClipIndex = tutorialClipIndex % tutorialClips.Length;
        }

        VP.clip = tutorialClips[tutorialClipIndex];
        VP.Play();
    }

    public void UnChangeClip()
    {
        tutorialClipIndex--;

        if (tutorialClipIndex <= tutorialClips.Length)
        {
            tutorialClipIndex = 0;
        }

        VP.clip = tutorialClips[tutorialClipIndex];
        VP.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialClipIndex == 0)
        {
            tutorialTitles[0].SetActive(true);
            tutorialArrows[0].SetActive(false);
            tutorialArrows[1].SetActive(true);
        }
        else tutorialTitles[0].SetActive(false);
        if (tutorialClipIndex == 1)
        {
            tutorialTitles[1].SetActive(true);
            tutorialArrows[0].SetActive(true);
            tutorialArrows[1].SetActive(true);
        }
        else tutorialTitles[1].SetActive(false);
        if (tutorialClipIndex == 2)
        {
            tutorialTitles[2].SetActive(true);
            tutorialArrows[1].SetActive(false); 
        }
        else tutorialTitles[2].SetActive(false);

     
    }


}
