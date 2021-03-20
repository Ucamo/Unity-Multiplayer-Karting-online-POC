using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpNameWinner : MonoBehaviour
{
    void Start()
    {
        if(ValuesBetweenScenes.NameOfWinner!=null){
            GetComponent<TextMeshProUGUI>().text=ValuesBetweenScenes.NameOfWinner +" Won!";
        }        
    }

}
