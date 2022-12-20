using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitSimple : MonoBehaviour{

	public string NextLevel = "MainMenu";
	public int stardustNeeded = 5;
	public GameObject notEnoughSign;

	void Start(){
		notEnoughSign.SetActive(false);
	}

	public void OnTriggerEnter2D(Collider2D other){
		Debug.Log("I hit something");
		if (other.gameObject.transform.parent.tag == "Player"){
			
			if (stardustNeeded <= GameHandler.gotTokens){
				SceneManager.LoadScene (NextLevel);
			}
			
			else {
				notEnoughSign.SetActive(true);
			}
		}
	}


	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.transform.parent.tag == "Player"){
			notEnoughSign.SetActive(false);
		}
	}



      // public void OnCollisionEnter2D(Collision2D other){
            // if (other.gameObject.transform.parent.tag == "Player"){
                  // SceneManager.LoadScene (NextLevel);
            // }
      // }

}
