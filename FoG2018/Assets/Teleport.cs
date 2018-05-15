using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    public Transform[] tp;

    Transform RandPos(){ 
        return tp[Random.Range(0,tp.Length)];    
    }

    private void OnTriggerEnter(Collider other) {
        Transform t = RandPos();
        other.transform.rotation=t.rotation;
        other.transform.position=t.position;
    }
}
