using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;


namespace Photon.Pun
{
public class Disconect : MonoBehaviour
{
    void Start(){
        PhotonNetwork.Disconnect ();
    }
}
}
