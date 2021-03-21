using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using KartGame.KartSystems;

public class PlayerInfo : MonoBehaviour
{
    public string PlayerName;
    public int PlayerPosition;

    public int currentPlayerLap;

    void Start()
    {
       //Start the coroutine we define below named SetupName.
        StartCoroutine(WaitToSetupName());
    }

    IEnumerator WaitToSetupName()
    {
        //yield on a new YieldInstruction that waits for 1 second.
        yield return new WaitForSeconds(1);
        SetupName();
    }
    void SetupName(){
		PhotonView objView = gameObject.GetComponent<PhotonView>();
        if(objView!=null){
            PlayerName= objView.Owner.NickName;
            //Destroy component that enables the player to move if it's not the instance you are controlling, preventing moving all the players on you local instance
			//at the same time.
			if(!objView.IsMine){
				gameObject.GetComponent<ArcadeKart>().enabled = false;
			}	
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name.Contains("LapCheckpoint")){
            currentPlayerLap--;
        }
    }
    
}
