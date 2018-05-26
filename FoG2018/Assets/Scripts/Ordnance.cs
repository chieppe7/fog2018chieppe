using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;

public class Ordnance : NetworkBehaviour {

    public GameObject missile;
    public float cooldown;

    private bool charging=false;
	
    IEnumerator FireInAHole() { 
        charging=true;
        CmdOrdnance();
        yield return new WaitForSeconds(cooldown);
        charging=false;
    }

    [Command]
    void CmdOrdnance() { 
         // Create the Bullet from the Bullet Prefab
        var ordnance = (GameObject)Instantiate (
            missile,
            this.transform.position,
            this.transform.rotation);

        // Add velocity to the bullet
        NetworkServer.Spawn(ordnance);
    }

	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer)
            return;
		if(Input.GetButtonDown("Fire2")&&!charging){ 
                StartCoroutine(FireInAHole());
        }
	}
}
