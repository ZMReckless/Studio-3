using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioLevels : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider, musicSlider, sfxSlider;

    public static readonly string FirstPlay = "FirstPlay";
    public static readonly string MasterPref = "MasterPref";
    public static readonly string MusicPref = "MusicPref";
    public static readonly string SFXPref = "SFXPref";

    private int firstPlayInt;
    private float masterFloat, musicFloat, sfxFloat;

    public void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt("FirstPlay");
        // sets values to maximum if first time opening
        if (firstPlayInt == 0)
        {
            masterFloat = 1f;
            musicFloat = 1f;
            sfxFloat = 1f;
            masterSlider.value = masterFloat;
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;

            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SFXPref, sfxFloat);

            PlayerPrefs.SetInt(FirstPlay, 1);
        }

        else
        {
            masterFloat = PlayerPrefs.GetFloat(MasterPref);
            masterSlider.value = masterFloat;
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            sfxFloat = PlayerPrefs.GetFloat(SFXPref);
            sfxSlider.value = sfxFloat;
        }
    }

    public void Update()
    {
        masterFloat = masterSlider.value;
        musicFloat = musicSlider.value;
        sfxFloat = sfxSlider.value;
        Debug.Log(PlayerPrefs.GetFloat(MasterPref));
        Debug.Log(PlayerPrefs.GetFloat(MusicPref));
        Debug.Log(PlayerPrefs.GetFloat(SFXPref));
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SFXPref, sfxSlider.value);
        Debug.Log("Sound settings have been saved");
    }
    // saves sound setting when clicked out of application
    public void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        audioMixer.SetFloat("MasterVol", Mathf.Log10(masterFloat <= 0 ? 0.001f : masterFloat) * 40f);
        audioMixer.SetFloat("MusicVol", Mathf.Log10(musicFloat <= 0 ? 0.001f : musicFloat) * 40f);
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sfxFloat<= 0 ? 0.001f : sfxFloat) *40f);
    }
}
