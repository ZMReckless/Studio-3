using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public ParticleSystem shotAtEffect; //blood
    public Collider primaryCollider; //ragdoll
    public Collider[] allColliders; //ragdoll

    public Camera mainCam; //killcam
    public Camera killCam; //killcam
    public GameObject canvases; //killcam

    private void Awake() //ragdoll
    {
        primaryCollider = GetComponent<Collider>(); 
        allColliders = GetComponentsInChildren<Collider>(true);
        EnableRagdoll(false);
    }

    public void EnableRagdoll(bool ragDollEnabled) //ragdoll
    {
        foreach (var col in allColliders)
            col.enabled = ragDollEnabled;
        primaryCollider.enabled = !ragDollEnabled;
        GetComponent<Rigidbody>().useGravity = !ragDollEnabled;
        GetComponent<Animator>().enabled = !ragDollEnabled;
        
    }

    public void GetShot() //blood //killcam
    {
        shotAtEffect.Play();
        EnableKillCam();
    }

    public void EnableKillCam() //killcam
    {
        mainCam.enabled = false;
        killCam.enabled = true;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        canvases.SetActive(false);
    }

    
}
