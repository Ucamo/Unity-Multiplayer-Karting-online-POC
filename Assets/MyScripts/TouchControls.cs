using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using Photon.Pun;

public class TouchControls : MonoBehaviour
{
    public GameObject TouchControlHolder;
    bool ShowControls;
    GameObject myPlayer; 

    bool isForward=false;
    bool isBackward=false;
    bool isLeft=false;
    bool isRight=false;

    void Start(){
        //Fin all PhotonViews
        StartCoroutine(WaitToSetupPlayer());
    }

    IEnumerator WaitToSetupPlayer()
    {
        //yield on a new YieldInstruction that waits for 1 second.
        yield return new WaitForSeconds(2);
        SetupName();
    }

    void SetupName(){
        GameObject[] listPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in listPlayers){
            PhotonView pView = player.GetComponent<PhotonView>();
            if(pView!=null){
                if(pView.IsMine){
                    myPlayer=player;
                }
            }
        }
    }

    void Update(){
        HandleMovement();
    }

    void HandleMovement(){
        if(isForward){
            myPlayer.GetComponent<TouchInput>().valY=1;
        }
        if(isBackward){
            myPlayer.GetComponent<TouchInput>().valY=-1;
        }
        if(isLeft){
            myPlayer.GetComponent<TouchInput>().valX=-1;
        }
        if(isRight){
            myPlayer.GetComponent<TouchInput>().valX=1;
        }
    }
    

    public void MoveForward(){
        isForward=true;
    }
    public void MoveBackward(){
        isBackward=true;
    }
    public void MoveLeft(){
        isLeft=true;
    }
    public void MoveRight(){
        isRight=true;
    }

    public void ResetData(){
        isForward=false;
        isBackward=false;
        isLeft=false;
        isRight=false;
    }

    public void ShowTouchControls(){
        if(!ShowControls){
            TouchControlHolder.SetActive(true);
            ShowControls=true;
        }else{
            TouchControlHolder.SetActive(false);
            ShowControls=false;
        }
    }
}
