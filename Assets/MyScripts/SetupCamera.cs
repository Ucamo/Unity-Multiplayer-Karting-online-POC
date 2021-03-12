using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun.Demo.PunBasics;

public class SetupCamera : MonoBehaviour
{

    void Start()
    {
       //Start the coroutine we define below named SetupCamera.
        StartCoroutine(WaitToSetupCamera());
    }

    IEnumerator WaitToSetupCamera()
    {
        //yield on a new YieldInstruction that waits for 1 second.
        yield return new WaitForSeconds(1);
        SetupCinemachineVirtualCamera();
    }
    void SetupCinemachineVirtualCamera(){
		GameObject cinemachineVC = GameObject.Find("CinemachineVirtualCamera");
		if(cinemachineVC!=null){

            GameObject gameManager = GameObject.Find("Game Manager");
            GameObject playerPrefab;
            if(gameManager!=null){
                playerPrefab= gameManager.GetComponent<GameManager>().GetPlayerPrefab();

                if(playerPrefab!=null){
                    cinemachineVC.GetComponent<CinemachineVirtualCamera>().Follow=playerPrefab.transform;
			        cinemachineVC.GetComponent<CinemachineVirtualCamera>().LookAt=playerPrefab.transform;
                }else{
                     Debug.LogError("PlayerPrefab not found");
                }
            }else{
                 Debug.LogError("GameManager not found");
            }			
		}else{
            Debug.LogError("Cinemachine virtual camera not found");
        }
	}
}
