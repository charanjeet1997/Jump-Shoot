using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCollisionChange : MonoBehaviour
{
    public BoxCollider2D stepCollider;
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(other.transform.position.y < transform.position.y)
            {
                stepCollider.isTrigger = true;
                return;
            }
            stepCollider.isTrigger = false;
        }
    }
    
}
