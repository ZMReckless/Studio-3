using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Kick_Back : MonoBehaviour
{
    public Animator hammerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HammerKickBack()
    {
        hammerAnimator.SetTrigger("Hammer_Kicked");
    }
}
