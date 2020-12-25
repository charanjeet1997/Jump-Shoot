using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPlayerFall : MonoBehaviour
{
    public UnityEvent OnPlayerFall;
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Debug.Log("PlayerFall");
            OnPlayerFall?.Invoke();
        }
    }
}
