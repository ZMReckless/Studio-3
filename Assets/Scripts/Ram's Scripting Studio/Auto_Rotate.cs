using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Rotate : MonoBehaviour
{
    public float rotationSpeed;
    public Material team1;
    public Material team2;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.root.gameObject.CompareTag("Team1"))
        {
            GetComponent<Renderer>().material = team1;
        }
        if (transform.root.gameObject.CompareTag("Team2"))
        {
            GetComponent<Renderer>().material = team2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10 * rotationSpeed * Time.deltaTime, 0);
    }
}
