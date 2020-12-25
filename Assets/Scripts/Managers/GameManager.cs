using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerStartPoint;
    public Camera mainCamera;
    public Canvas mainScreen;
    GameObject player;
    

    public static GameManager instance;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        mainCamera = GameCameraManager.Instance.mainCamera;
        //player = Instantiate(playerPrefab,playerStartPoint.position,Quaternion.identity);
    }

    public void ResetGame()
    {
        mainCamera.transform.position = new Vector3(0,0,-10);
        player = Instantiate(playerPrefab,playerStartPoint.position,Quaternion.identity);
        mainScreen.enabled = false;
    }
    public void OnPlayerFall()
    {
        Destroy(player);
        mainScreen.enabled = true;
    }    
}
