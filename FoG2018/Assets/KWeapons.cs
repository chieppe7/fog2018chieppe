using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;

public class KWeapons : NetworkBehaviour {

    public GameObject projectile;
    public float delay;
    public Transform[] T;

    [SyncVar]
    private int i=0;
    private int j=0;
    private bool isShooting=false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
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
        yield return new WaitForSeconds(0f);
        if(i<T.Length&&j<T.Length)
            StartCoroutine(Fire());
        else {
            StartCoroutine(DelayFire());
        }
    }

    IEnumerator DelayFire() {
        yield return new WaitForSeconds(delay);
        j=0;
        isShooting=false;
    }

    [Command]
    void CmdFire() { 
         // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate (
            projectile,
            T[i].position,
            T[i++].rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        if(i>=T.Length)
            i=0;

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 300f;
        NetworkServer.Spawn(bullet);
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
