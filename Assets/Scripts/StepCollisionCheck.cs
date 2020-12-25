using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCollisionCheck : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    bool isPlayerGrounded = false;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player")
        {
            isPlayerGrounded = true;
            GameScoreManager.Instance.UpdateScore(1);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.tag == "Player")
        {
            if(isPlayerGrounded)
            {
                isPlayerGrounded = false;
                StartCoroutine(StepPooling());
            }
        }
    }
    IEnumerator StepPooling()
    {
        yield return new WaitForSeconds(0.2f);
        StepInstantiateManager.Instance.StepPulling(transform.parent.gameObject);
        boxCollider.isTrigger  = true;
    }
}
