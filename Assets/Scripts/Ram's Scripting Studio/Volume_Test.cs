using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Volume_Test : MonoBehaviour
{
    [SerializeField]
    private Volume volume;

    private float thresholdValue = 0.5f;
    private float changeAmount = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        volume = FindObjectOfType<Volume>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            
            
        }
    }


}
