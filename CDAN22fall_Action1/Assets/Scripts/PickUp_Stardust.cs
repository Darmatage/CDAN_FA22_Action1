using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Stardust: MonoBehaviour {
       private GameHandler gameHandler;
public GameObject theArt;
public GameObject theArt2;



       void Start() {
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.transform.parent.tag == "Player"){
      gameObject.GetComponent<AudioSource>().Play();
			gameHandler.playerGetTokens(1);
      theArt.SetActive(false);
      theArt2.SetActive(false);
	     StartCoroutine(DelayKill());
		}
	}




  IEnumerator DelayKill(){
    yield return new WaitForSeconds(0.55f);
    Destroy(gameObject);

  }

}
