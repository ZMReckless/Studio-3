using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCude : MonoBehaviour
{

    public Transform cude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = cude.position;

    }
}
