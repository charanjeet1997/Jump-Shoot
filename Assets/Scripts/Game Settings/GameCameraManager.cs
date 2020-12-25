using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraManager : MonoBehaviour
{
    public Camera mainCamera;
    
    public static GameCameraManager Instance;
    private void Awake() {
        Instance = this;
    }

    public float GetAspectRatioSum()
    {
        float aspectRationSum;
        aspectRationSum = (float)Screen.width/(float) Screen.height;
        return aspectRationSum;
    }

    public float GetCameraOrthographicSize()
    {
        float cameraSize = 0;
        cameraSize = mainCamera.orthographicSize;
        return cameraSize;
    }

    public Vector2[] GetBoundriesPositions()
    {
        Vector2[] gameBoundries = new Vector2[2];
        gameBoundries[0] = new Vector2(GetCameraOrthographicSize() * GetAspectRatioSum(),0);
        gameBoundries[1] = new Vector2(-GetCameraOrthographicSize() * GetAspectRatioSum(),0); 
        return gameBoundries;
    }

    public bool CheckIsWideScreen()
    {
        if(((float)Screen.height/(float)Screen.width) > 1.8f)
        {
            return true;
        }
        return false;
    }
}
