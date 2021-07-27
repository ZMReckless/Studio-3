using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Shake : MonoBehaviour
{
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScreenShake()
    {
        cameraAnimator.SetTrigger("ShakeScreen");
    }
}
