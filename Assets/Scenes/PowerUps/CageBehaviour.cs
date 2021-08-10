using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CageBehaviour : MonoBehaviourPunCallbacks
{
    public Animator animator;

    public float delayLength = 3f;
    public float debrisLength = 1f;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        photonView.RPC("StartTrap", RpcTarget.All);
    }

    public void StartTrap()
    {
        StartCoroutine(TrapPlayer());
    }

    IEnumerator TrapPlayer()
    {
        yield return new WaitForSeconds(delayLength);

        animator.SetTrigger("BreakCage");
        Debug.Log("Cage has been broken!");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + debrisLength);

        PhotonNetwork.Destroy(gameObject);
    }
}
