using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CloseContact_Shader : MonoBehaviour
{
    public Material mat;
    private float thresholdValue = 1f;
    private float deTriggerThresholdValue = 0f;
    private float thresholdChangeAmount = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            
            StartCoroutine(TriggerCloseContact());

        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            
            StartCoroutine(DeTriggerCloseContact());
        }
    }

    IEnumerator TriggerCloseContact()
    {
        
        while(thresholdValue > 0)
        {
            yield return new WaitForSeconds(0);
            StopCoroutine(DeTriggerCloseContact());
            thresholdValue -= thresholdChangeAmount;
            mat.SetFloat("Threshold", thresholdValue);
            
        }
        
        

    }

    IEnumerator DeTriggerCloseContact()
    {
        
        while (deTriggerThresholdValue < 1)
        {
            yield return new WaitForSeconds(0);
            StopCoroutine(TriggerCloseContact());
            deTriggerThresholdValue += thresholdChangeAmount;
            mat.SetFloat("Threshold", deTriggerThresholdValue);
            
        }
        
    }

}
