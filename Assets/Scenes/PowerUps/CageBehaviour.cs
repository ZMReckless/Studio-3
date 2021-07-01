using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageBehaviour : MonoBehaviour
{
    public Animator animator;

    private GameObject playerObject;

    public float trapDescent = 5f;
    public float delayLength = 3f;
    public float debrisLength = 1f;

    private bool trapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject = other.gameObject;

            if (!trapping)
            {
                StartCoroutine(TrapPlayer());
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (!trapping)
            {
                DestroyCage();
            }
        }
    }

    IEnumerator TrapPlayer()
    {
        Vector3 trapLocation = new Vector3(playerObject.transform.position.x,
                playerObject.transform.position.y + trapDescent, playerObject.transform.position.z);

        gameObject.transform.position = trapLocation;
        trapping = true;

        yield return new WaitForSeconds(delayLength);

        DestroyCage();
    }

    private void DestroyCage()
    {
        animator.SetTrigger("BreakCage");
        Debug.Log("Cage has been broken!");
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + debrisLength);
    }
}
