using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CloseContact_Shader : MonoBehaviour
{
    public Material mat;
    private float thresholdValue = 1f;
    private float deTriggerThresholdValue = 0f;
    private float thresholdChangeAmount = 0.025f;

    IEnumerator TriggerCloseContact()
    {
        while (thresholdValue > 0)
        {
            yield return new WaitForSeconds(0);

            thresholdValue -= thresholdChangeAmount;
            mat.SetFloat("Threshold", thresholdValue);

            if (thresholdValue <= 0)
            {
                thresholdValue = 0;
                if (thresholdValue == 0)
                {
                    StopAllCoroutines();
                }
            }
        }
    }

    IEnumerator DeTriggerCloseContact()
    {
        while (deTriggerThresholdValue < 1)
        {
            yield return new WaitForSeconds(0);

            thresholdValue += thresholdChangeAmount;
            mat.SetFloat("Threshold", thresholdValue);

            if (thresholdValue >= 1)
            {
                thresholdValue = 1;
                if (thresholdValue == 1)
                {
                    StopAllCoroutines();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerCloseContact());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DeTriggerCloseContact());
        }
    }
}
