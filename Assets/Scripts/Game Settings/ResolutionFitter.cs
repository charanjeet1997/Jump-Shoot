using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFitter : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject boundry1,boundry2;
    private void Start() {
        SetBoundriyObjectsPosition();
        SetBoundryObjectsScale();
    }

    private void SetBoundriyObjectsPosition()
    {
        boundry1.transform.position = GameCameraManager.Instance.GetBoundriesPositions()[0];
        boundry2.transform.position = GameCameraManager.Instance.GetBoundriesPositions()[1];
    }

    private void SetBoundryObjectsScale()
    {
        boundry1.transform.localScale = new Vector3(2.5f,GameCameraManager.Instance.GetCameraOrthographicSize() * 5,1);
        boundry2.transform.localScale = new Vector3(2.5f,GameCameraManager.Instance.GetCameraOrthographicSize() * 5,1);
    }

}
