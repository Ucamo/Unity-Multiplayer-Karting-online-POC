using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name.Contains("LapCheckpoint")){
            currentPlayerLap--;
        }
    }
    
}
