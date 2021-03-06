﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HealthController : NetworkBehaviour {

    public Image healthBar;
    public int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;
    public AudioSource AS;

     private NetworkStartPosition[] spawnPoints;

	// Use this for initialization
	void Start () {
		currentHealth=maxHealth;

        if (isLocalPlayer) {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
	}

    public void TakeDamage(int amount) {
        if(!isServer)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0) {
            currentHealth = maxHealth;
            AS.Play();
            RpcRespawn();
        }
        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn() {
        if (isLocalPlayer)
        {
            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // If there is a spawn point array and the array is not empty, pick one at random
            if (spawnPoints != null && spawnPoints.Length > 0) {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
    }

    void OnChangeHealth (int currentHealth) {
        healthBar.fillAmount = (float)currentHealth/(float)maxHealth;
    }
}
