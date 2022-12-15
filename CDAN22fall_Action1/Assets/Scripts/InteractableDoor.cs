using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableDoor : MonoBehaviour{

        public string NextLevel = "MainMenu";
        public GameObject msgPressE;
        public bool canPressE =false;

       void Start(){
              msgPressE.SetActive(false);
        }

       void Update(){
              if ((canPressE == true) && (Input.GetKeyDown(KeyCode.E))){
                     EnterDoor();
              }
        }

        void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player"){ ;
                     msgPressE.SetActive(true);
                     canPressE =true;
              }
        }

        void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player"){
                     msgPressE.SetActive(false);
                     canPressE = false;
              }
        }

      public void EnterDoor(){
            SceneManager.LoadScene (NextLevel);
      }

}
