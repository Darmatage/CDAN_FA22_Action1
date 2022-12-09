using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimal : MonoBehaviour{
	
    public GameObject charPigeon;
    public GameObject charBadger;
    public GameObject charBear;
    public Animator currentAnim;
    private int choiceAnimal;

    // Start is called before the first frame update
    void Start(){
      WhichAnimal(false);
	  currentAnim = charPigeon.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update(){
      if (Input.GetKeyDown("1")){
        Debug.Log("I pressed 1");
        choiceAnimal = 1;
        WhichAnimal(true);
      }
      if (Input.GetKeyDown("2")){
        Debug.Log("I pressed 2");
        choiceAnimal = 2;
        WhichAnimal(true);
      }
      if (Input.GetKeyDown("3")){
        Debug.Log("I pressed 3");
        choiceAnimal = 3;
        WhichAnimal(true);
      }
    }

    public void WhichAnimal(bool newSwitch){
      //this part is used any time the character is changed
       if (newSwitch == true){
        if (choiceAnimal == 1){
          GameHandler.currentBeast="bear";
          charPigeon.SetActive(false);
          charBadger.SetActive(false);
          charBear.SetActive(true);
          //currentAnim = charBear.GetComponentInChildren<Animator>();
          Debug.Log("1 = Bear time: " + choiceAnimal);
        }
        if (choiceAnimal == 2){
          GameHandler.currentBeast="badger";
          charPigeon.SetActive(false);
          charBadger.SetActive(true);
          charBear.SetActive(false);
          //currentAnim = charBadger.GetComponentInChildren<Animator>();
          Debug.Log("2 = Badger time: " + choiceAnimal);
        }
        if (choiceAnimal == 3){
          GameHandler.currentBeast="pigeon";
          charPigeon.SetActive(true);
          charBadger.SetActive(false);
          charBear.SetActive(false);
          currentAnim = charPigeon.GetComponentInChildren<Animator>();
          Debug.Log("3 = Pigeon time: " + choiceAnimal);
        }
      }
      //this part is used at start of scene
      else if (newSwitch == false){
        if (GameHandler.currentBeast=="bear"){
          charPigeon.SetActive(false);
          charBadger.SetActive(false);
          charBear.SetActive(true);
          //currentAnim = charBear.GetComponentInChildren<Animator>();
          Debug.Log("no switch, bear");
        }
        if (GameHandler.currentBeast=="badger"){
          charPigeon.SetActive(false);
          charBadger.SetActive(true);
          charBear.SetActive(false);
          //currentAnim = charBadger.GetComponentInChildren<Animator>();
          Debug.Log("no switch, badger");
        }
        if (GameHandler.currentBeast=="pigeon"){
          charPigeon.SetActive(true);
          charBadger.SetActive(false);
          charBear.SetActive(false);
          currentAnim = charPigeon.GetComponentInChildren<Animator>();
          Debug.Log("no switch, pigeon");
        }
      }

    }

}
