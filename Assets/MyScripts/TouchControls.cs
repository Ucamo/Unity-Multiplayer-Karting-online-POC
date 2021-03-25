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
    public VariableJoystick variableJoystick;

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
        if(myPlayer!=null && myPlayer.GetComponent<TouchInput>()!=null && variableJoystick!=null){
        myPlayer.GetComponent<TouchInput>().valY=variableJoystick.Vertical;
        myPlayer.GetComponent<TouchInput>().valX=variableJoystick.Horizontal;
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
