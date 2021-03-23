using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class PickRandomMaterial : MonoBehaviour
{
    public Material[] materialList;
    void Start()
    {
        if(materialList.Length>0){
            int index = Random.Range(0,materialList.Length-1);
            gameObject.GetComponent<SkinnedMeshRenderer> ().material = materialList[index];
        }
    }

}
