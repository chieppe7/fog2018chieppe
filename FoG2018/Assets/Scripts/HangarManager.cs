using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarManager : MonoBehaviour {

	public GameObject[] Hangars;

    public void ResetGame() { 
        for(int i=0;i<Hangars.Length;i++){ 
            Hangars[i].SetActive(true);    
        }    
    }
}
