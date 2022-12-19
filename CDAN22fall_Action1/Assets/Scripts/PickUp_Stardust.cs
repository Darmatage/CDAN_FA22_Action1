using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Stardust: MonoBehaviour {
       private GameHandler gameHandler;

       void Start() {
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.transform.parent.tag == "Player"){
			gameHandler.playerGetTokens(1);
			Destroy(gameObject);
		}
	}
	
}