using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDuration : MonoBehaviour
{
    private float stormTime = 0;
    public float stormDuration = 10f;

    private void OnEnable()
    {
        stormTime = 0;
    }

    void Update()
    {
        if (stormTime < stormDuration)
        {
            stormTime += Time.deltaTime;
        }
        else if (stormTime > stormDuration)
        {
            gameObject.SetActive(false);
        }
    }
}
