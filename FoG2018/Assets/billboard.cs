using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour {
	
    private Transform T;
    private GameObject[] G;
    private bool local;

    void Start() { 
        local = this.transform.parent.gameObject.GetComponent<Movement>().isLocalPlayer;
        G = GameObject.FindGameObjectsWithTag("Player");
        for(int i =0; i<G.Length; i++){ 
            if(G[i].GetComponent<CamRef>().isLocalPlayer){ 
                T=G[i].GetComponent<CamRef>().Cam.transform;
                return;
            }    
        }
    }

	// Update is called once per frame
	void Update () {
        if(local)
            return;
        if(T)
		    transform.LookAt(T);
	}
}
