using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// changes the position of the lantern pick up object
// the pivot point is at the bottom of the mesh and not the middle
public class ChangePositionStupid : MonoBehaviour
{
    void Start()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x,
            transform.position.y - 0.25f,
            transform.position.z);

        transform.position = newPosition;
    }
}
