using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {

    public GameObject[] enemyPrefab;
    public int numberOfEnemies;
    public float squareRadius;

    public override void OnStartServer() {

        

        for (int i=0; i < numberOfEnemies; i++) {
            var spawnPosition = new Vector3(
                Random.Range(-squareRadius, squareRadius),
                Random.Range(-squareRadius, squareRadius),
                Random.Range(-squareRadius, squareRadius));

            var spawnRotation = Quaternion.Euler( 
                Random.Range(0,180), 
                Random.Range(0,180), 
                Random.Range(0,180));

            var enemy = (GameObject)Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
}