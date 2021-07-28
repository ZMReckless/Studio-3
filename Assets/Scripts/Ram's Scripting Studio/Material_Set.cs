using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Set : MonoBehaviour
{
    public Material team1_Mat;
    public Material team2_Mat;

    // Start is called before the first frame update
    void Start()
    {
        if(this.CompareTag("Team1"))
        {
            Renderer[] children;
            children = GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                var mats = new Material[rend.materials.Length];
                for (int i = 0; i < rend.materials.Length; i++)
                {
                    mats[i] = team1_Mat;
                }
                rend.materials = mats;
            }
        }
        if (this.CompareTag("Team2"))
        {
            Renderer[] children;
            children = GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                var mats = new Material[rend.materials.Length];
                for (int i = 0; i < rend.materials.Length; i++)
                {
                    mats[i] = team2_Mat;
                }
                rend.materials = mats;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
