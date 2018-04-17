using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhantomWeapons : NetworkBehaviour {

    public GameObject projectile;
    public float delay;
    public Transform[] T;
    [SyncVar]
    private int i=0;
    private int j=0;
    private bool isShooting=false;
    
    void Update () {
		if(!isLocalPlayer)
            return;
        if(Input.GetButton("Fire1")&&!isShooting) {
            isShooting=true;
            StartCoroutine(Fire());    
        }
	}

    IEnumerator Fire() {
        j++;
        if(i<T.Length)
            CmdFire();
        yield return new WaitForSeconds(delay);
        if(i<T.Length&&j<T.Length)
            StartCoroutine(Fire());
        else {
            j=0;
            isShooting=false;
        }
    }

	[Command]
    void CmdFire() { 
        // Create the Bullet from the Bullet Prefab
        if(i%2!=0){ 
            var bullet1 = (GameObject)Instantiate (
            projectile,
            T[i].position+new Vector3(0.24f,0f,0f),
            T[i].rotation);
            var bullet2 = (GameObject)Instantiate (
            projectile,
            T[i].position+new Vector3(-0.24f,0f,0f),
            T[i++].rotation);
            if(i>=T.Length)
                i=0;
            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 100f;
            NetworkServer.Spawn(bullet1);
            // Destroy the bullet after 2 seconds
            Destroy(bullet1, 2.0f);
            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 100f;
            NetworkServer.Spawn(bullet2);
            // Destroy the bullet after 2 seconds
            Destroy(bullet2, 2.0f);
        }
        else {
            var bullet = (GameObject)Instantiate (
                projectile,
                T[i].position,
                T[i++].rotation);
            if(i>=T.Length)
                i=0;

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100f;
            NetworkServer.Spawn(bullet);
            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }
    }

}
