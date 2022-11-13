using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit_Switch : MonoBehaviour{

      public GameObject DoorClosedArt;
      public GameObject DoorOpenArt;
      public string NextScene = "MainMenu";

      void Start(){
            DoorClosedArt.SetActive(true);
            DoorOpenArt.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = false;
      }

      public void DoorOpen(){
            DoorClosedArt.SetActive(false);
            DoorOpenArt.SetActive(true);
            gameObject.GetComponent<Collider2D>().enabled = true;
      }

      void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene(NextScene);
            }
      }
}
