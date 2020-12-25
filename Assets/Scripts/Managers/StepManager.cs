using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public GameObject startPos,endPose;
    public GameObject movingStep;
    public float stepMaxPos;
    public int index;
    public float speed;
    public float maxSpeed,minSpeed;
    public bool clockWise;
    
    private void Start() {
        SetStepBoundries();
        float wideDifference = 0;
        speed = Random.Range(minSpeed,maxSpeed);
        if(GameCameraManager.Instance.CheckIsWideScreen())
        {
            wideDifference = 0.8f;
            stepMaxPos -= wideDifference;
        }
    }

    
    private void Update() {
        StepMovement();
    }
    public void SetStepBoundries()
    {
        Vector2 boundry1 = GameCameraManager.Instance.GetBoundriesPositions()[0];
        Vector2 boundry2 = GameCameraManager.Instance.GetBoundriesPositions()[1];
        startPos.transform.position = new Vector2(boundry2.x + 0.5f,endPose.transform.position.y);
        endPose.transform.position = new Vector2(boundry1.x - 0.5f,startPos.transform.position.y);
    }

    public void StepMovement()
    {
        if(clockWise)
        {
            movingStep.transform.position = new Vector3(Mathf.Cos(Time.time * speed) * stepMaxPos,movingStep.transform.position.y);
        }
        else
        {
            movingStep.transform.position = new Vector3(Mathf.Cos(Time.time * speed) * -stepMaxPos,movingStep.transform.position.y);
        }
    }

}
