using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitSimple : MonoBehaviour{

      public string NextLevel = "MainMenu";


      public void OnTriggerEnter2D(Collider2D other){
		  Debug.Log("I hit something");
            if (other.gameObject.transform.parent.tag == "Player"){
                  SceneManager.LoadScene (NextLevel);
            }
      }


      // public void OnCollisionEnter2D(Collision2D other){
            // if (other.gameObject.transform.parent.tag == "Player"){
                  // SceneManager.LoadScene (NextLevel);
            // }
      // }

}
