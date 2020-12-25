using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb_player;
    private Vector2 playerPos,mousePose,dispPos;
    private float dot_disp; 
    public bool isGrounded;
    public float jumpForce;
    public float downForce;
    float clockWise = 1;
    public Vector2 jumpDirection;
    private void Update() {
        PlayerJump();
    }

    private Vector2 GetWorldPosition(Vector2 mousePose)
    {
        return GameCameraManager.Instance.mainCamera.ScreenToWorldPoint(mousePose);
    }

    void PlayerJump()
    {
        if(Input.GetMouseButtonDown(0) && isGrounded)
        {
            mousePose = GetWorldPosition(Input.mousePosition);
            dispPos = (mousePose - (Vector2)transform.position).normalized;
            rb_player.velocity = ((dispPos * jumpDirection) + Vector2.up  * jumpForce * clockWise);
        }
        
        else if(Input.GetMouseButtonDown(0) && !isGrounded)
        {
            StartCoroutine(ForceDown());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject != null && other.collider.tag == "Ground")
        {
            transform.parent = other.transform;
            isGrounded = true;
            rb_player.velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.collider.gameObject != null && other.collider.tag == "Ground")
        {
            transform.parent = null;
            isGrounded = false;
        }
    }

    IEnumerator ForceDown()
    {
        rb_player.gravityScale = 0;
        rb_player.velocity = Vector3.zero;
        yield return new WaitForSeconds(.1f);
        rb_player.gravityScale = 1;
        rb_player.velocity = (Vector2.up * -clockWise * downForce);
    }
}
