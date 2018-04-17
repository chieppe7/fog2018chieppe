using UnityEngine;
using System.Collections; 

 public class CameraFollow : MonoBehaviour {

     public Transform playerTransform;
     public Vector3 offsetPosition;
     private Camera cam;
     private Vector3 off;
     private Vector3 Aux;
     private int c=0;

    private void Start() {
        Aux=offsetPosition;
        cam=this.gameObject.GetComponent<Camera>();
         if(!playerTransform.gameObject.GetComponent<Movement>().isLocalPlayer) {
             cam.enabled = false;
             return;
         }
    }

    // Update is called once per frame
    void Update() {
         if(playerTransform != null) {
             transform.position = playerTransform.TransformPoint(Aux);
             transform.LookAt(playerTransform);
         }
     }

    IEnumerator offset() { 
        Aux = off;
        yield return new WaitForSeconds(5f);
        Aux = offsetPosition;
        c=0;
    }

    private void OnTriggerEnter(Collider other) {
        c-=5;
        off= new Vector3 (0f,offsetPosition.y,offsetPosition.z+(float)c);
        StartCoroutine(offset());
    }
}
