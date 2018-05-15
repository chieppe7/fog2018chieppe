using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileBoom : MonoBehaviour {

	public GameObject mis;
    private AudioSource AS;

    private void Awake() {
        StartCoroutine(byebye());
        AS = GameObject.FindGameObjectWithTag("SOUND").GetComponent<AudioSource>();
    }

    IEnumerator byebye(){ 
        yield return new WaitForSeconds(5f);
        Destroy(mis);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Cabum");
        if(other.gameObject.layer==11){ 
            AS.Play();
            other.gameObject.SetActive(false);    
        }
        AS.Play();
        Destroy(mis);
    }
}
