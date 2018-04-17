using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDMG : MonoBehaviour {

    Rigidbody rig;
    float dmg;
	// Use this for initialization
	void Start () {
		rig=this.gameObject.GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit! colision");
        HealthController h = other.gameObject.GetComponent<HealthController>();
        Rigidbody rig2 = other.gameObject.GetComponent<Rigidbody>();
        if(h) {
            dmg=(rig.mass/rig2.mass) * 10f;
            h.TakeDamage((int)dmg);
        }
    }
}
