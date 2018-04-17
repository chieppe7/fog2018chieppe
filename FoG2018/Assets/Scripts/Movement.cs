using UnityEngine;
using System;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public float NimbleFactor;
    private float Energy=1f;
    public float engine;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer)
            return;
        moveController();
	}

    void moveController() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		if(h*h+v*v<0.1){
            Vector3 previousEulerAngles = transform.eulerAngles;
            Vector3 targetEulerAngles = previousEulerAngles;
            if (targetEulerAngles.z <= 180f)
                targetEulerAngles.z -= (targetEulerAngles.z * Time.deltaTime * 1.3f);
            else
                targetEulerAngles.z += (targetEulerAngles.z * Time.deltaTime * .2f);
            transform.eulerAngles = targetEulerAngles;
        }
		//anim.SetBool("IsMoving",true);

		transform.Rotate(transform.up * h * NimbleFactor, Space.World);
        transform.Rotate(transform.right * v * NimbleFactor, Space.World);
        transform.Translate (transform.forward * (Energy*engine) * Time.deltaTime, Space.World);
		//rig.AddForce(movement*engine, ForceMode.Acceleration);
		//rig.velocity=Vector3.ClampMagnitude(rig.velocity, ASpeed);
	}
}

[Serializable]
class ShipEngine {

}
