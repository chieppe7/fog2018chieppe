using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    private Rigidbody RG;

    private void Awake() {
        RG=gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        RG.AddForce (transform.forward * 500f);
		RG.velocity=Vector3.ClampMagnitude(RG.velocity, 130f);
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Target Acquired");
        if(other.gameObject.layer==11){ 
            this.transform.LookAt(other.transform);    
        }
    }
}
