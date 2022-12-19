using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Heart: MonoBehaviour {
       private GameHandler gameHandler;

       void Start() {
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

       void OnTriggerEnter2D(Collider2D other) {
              if ((other.gameObject.transform.parent.tag == "Player") && (GameHandler.Lives < gameHandler.maxLives)){
                   gameHandler.UpdateLives (1, "up");
                  //playerPowerupVFX.powerup();
                  Destroy(gameObject);
              } else {
				  Debug.Log("You already have maximum lives");
			  }
       }
}