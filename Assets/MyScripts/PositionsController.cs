using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using KartGame.KartSystems;

public class PositionsController : MonoBehaviour
{
    public int totalPlayers;
    PlayerInfo[] allPlayerInfo;
    Text tableText;
    GameFlowManager flowManager;
    void Start()
    {
       //Start the coroutine we define below
        StartCoroutine(WaitSetupPositions());
        tableText = gameObject.GetComponent<Text>();
        tableText.text="Starting...";
        GameObject objManager = GameObject.Find("RaceGameManager");
        if(objManager!=null){
            flowManager = objManager.GetComponent<GameFlowManager>();
        }
    }

    void Update(){
        SetupPositions();
        DeterminePositions();
        bool isEndGame = flowManager.GetEndGame();
        if(isEndGame){
            SetFirstPositionPlayerName();
        }
    }

    IEnumerator WaitSetupPositions()
    {
        //yield on a new YieldInstruction that waits for 1 second.
        yield return new WaitForSeconds(1);
        SetupPositions();
    }
    void SetupPositions(){
		allPlayerInfo = FindObjectsOfType(typeof(PlayerInfo)) as PlayerInfo[];
        totalPlayers=allPlayerInfo.Length;
	}

    void DeterminePositions(){
        if(allPlayerInfo!=null){
            if(allPlayerInfo.Length>0){
                PlayerInfo[] ordered_Players = allPlayerInfo.OrderBy(i => i.currentPlayerLap).ToArray();
                int counter=1;
                tableText.text="";
                foreach(PlayerInfo order in ordered_Players){
                    tableText.text+="#"+counter +" - "+order.PlayerName+"\n";
                    order.PlayerPosition=counter;
                    counter++;                    
                }
            }
        }
    }

    public void SetFirstPositionPlayerName(){
        if(allPlayerInfo!=null){
            if(allPlayerInfo.Length>0){
                PlayerInfo[] ordered_Players = allPlayerInfo.OrderBy(i => i.currentPlayerLap).ToArray();
                string nameFirstPosition=ordered_Players[0].PlayerName;
                ValuesBetweenScenes.NameOfWinner=nameFirstPosition;
            }
        }
    }


}
