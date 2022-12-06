using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

       public GameHandler gameHandler;
       public Transform pSpawn;       // current player spawn point

       void Start() {
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

       void Update() {
		   //respawn system without hearts
              if (pSpawn != null){
                     if ((GameHandler.playerHealth <= 0)&& (GameHandler.Lives > 0)){
                            //comment out lines from GameHandler about EndLose screen
                            Debug.Log("I am going back to the last spawn point");
                            Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, 0);
                            gameObject.transform.position = pSpn2;
                     }
              }
       }

	//respawn system with heart
	public void RespawnHearts() {
		if (pSpawn != null){
			Debug.Log("I am going back to the last spawn point");
			Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, 0);
			gameObject.transform.position = pSpn2;
		}
	}


	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Checkpoint"){
                            pSpawn = other.gameObject.transform;
                            GameObject thisCheckpoint = other.gameObject;
                            StopCoroutine(changeColor(thisCheckpoint));
                            StartCoroutine(changeColor(thisCheckpoint));
              }
       }

       IEnumerator changeColor(GameObject thisCheckpoint){
              Renderer checkRend = thisCheckpoint.GetComponentInChildren<Renderer>();
              checkRend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              yield return new WaitForSeconds(0.5f);
              checkRend.material.color = Color.white;
       }
}
