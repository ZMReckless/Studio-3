using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobile_Border : MonoBehaviour
{

    public Material blue;
    public Material red;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.root.CompareTag("Team1"))
        {
            GetComponent<Image>().material = blue;
        }

        if (transform.parent.root.CompareTag("Team2"))
        {
            GetComponent<Image>().material = red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
