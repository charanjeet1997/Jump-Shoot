using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepInstantiateManager : MonoBehaviour
{
    public GameObject[] stepPrefabs;
    public int numberOfSteps;
    public Transform playerStartPos;
    public float stepDifference;
    public static StepInstantiateManager Instance;
    [SerializeField]private List<GameObject> steps = new List<GameObject>();

    private void Awake() {
        Instance = this;
    }

    public void SetSteps()
    {
        for (int stepIndex = 0; stepIndex < numberOfSteps; stepIndex++)
        {
            GameObject step = Instantiate(stepPrefabs[Random.Range(0,stepPrefabs.Length)],this.transform);
            step.transform.position = Vector3.zero;
            steps.Add(step);
        }

        SetStepsPosition();
    }
    public void RemoveAllSteps()
    {
        for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
        {
            Destroy(steps[stepIndex]);
        }
        steps.Clear();
    }

    private void SetStepsPosition()
    {
        steps[0].transform.position = new Vector3(0,playerStartPos.position.y + stepDifference,0);
        for (int stepIndex = 1; stepIndex < steps.Count; stepIndex++)
        {
            if(steps[stepIndex-1] != null)
            {
                steps[stepIndex].transform.position = new Vector3(0,steps[stepIndex-1].transform.position.y + stepDifference,0);
            }    
        }   
    }

    public void StepPulling(GameObject step){
        for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
        {
            if(steps[stepIndex] == step)
            {   
                GameObject st = steps[stepIndex];
                steps.Remove(steps[stepIndex]);
                st.transform.position = new Vector3(0,steps[steps.Count-1].transform.position.y + stepDifference,0);
                steps.Add(st);   
            }
        }
    }
}
