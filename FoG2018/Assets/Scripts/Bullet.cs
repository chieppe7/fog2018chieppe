using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int dmg;

    public void OnTriggerEnter(Collider col) {
        Debug.Log("Hit!");
        HealthController h = col.gameObject.GetComponent<HealthController>();
        if(h)
            h.TakeDamage(dmg);
        Destroy(gameObject);
    }
}
