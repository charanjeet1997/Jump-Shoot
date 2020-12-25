using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementOnPlayerJump : MonoBehaviour
{
    public Camera mainCamera;
    public float cameraMovementSpeed;
    public float YOffset;
    private void Start() {
        mainCamera = GameCameraManager.Instance.mainCamera;
        YOffset = mainCamera.transform.position.y - transform.position.y;
    }

    private void Update() 
    {
        if(mainCamera != null)
        {
            if(transform.position.y > mainCamera.transform.position.y * 0.8f)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(0,transform.position.y + YOffset,-10),Time.deltaTime * cameraMovementSpeed);
            }
        }
    }
}
