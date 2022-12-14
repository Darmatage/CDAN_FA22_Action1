using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RechargeTimer2 : MonoBehaviour {
       public float energyMax =5f;       //set the number of seconds here (both floats can be static)
       public float energyTimer = 0f;
       public bool thingOn = false;
       private bool isFlying = false;

       public GameObject chargeTimer;
       public GameObject display;
       public float flyTime = 3f;

       public float flyLimit = 0.25f;
       private Vector3 hMove;

       void Awake(){
           energyTimer = energyMax;
           chargeTimer.SetActive (false);
        }

       void Update(){
            //hMove = new Vector3(Input.GetAxis("Vertical"), 0.0f, 0.0f);

            if ((GameHandler.currentBeast=="pigeon")&&(Input.GetAxis("Vertical") != 0)){
            //||(Input.GetKeyDown("f"))){
                chargeTimer.SetActive (true);
                thingOn = true;
                if (isFlying == false){
                  StartCoroutine(NotFlying());
                }
            } else if ((GameHandler.currentBeast=="bear")||(GameHandler.currentBeast=="badger")){
                //chargeTimer.SetActive (true);
                thingOn = false;
            }

            if (energyTimer > flyLimit){
              PlayerJump.flyEnergyEnough = true;
            } else {
              PlayerJump.flyEnergyEnough = false;
            }
        }

       void FixedUpdate(){
              if (thingOn == true){
                     energyTimer -= 0.01f;
                     Debug.Log("energy down: " + energyTimer);  //replace with the desired ability display
                     display.GetComponent<Image>().fillAmount = energyTimer / energyMax;
                     Color oldCol = display.GetComponent<Image>().color;
                     //if (oldCol.a > 0.01f){
                            // float r = oldCol.r - 0.005f;
                            //float g = oldCol.g - 0.005f;
                            // float b = oldCol.b - 0.005f;
                            //float a = oldCol.a;
                            // display.GetComponent<Image>().color = new Color(r,g,b,a);
                             //float x = display.localScale.x/1.005f;
                             //float y = display.localScale.y/1.005f;
                             //float z = display.localScale.z;
                             //display.localScale = new Vector3(x, y, z);
                     //}

                     if (energyTimer <= 0){
                            thingOn = false;
                                  // time has run out
                     }
              } else if (thingOn == false){
                     if (energyTimer < energyMax) {
                            energyTimer += 0.01f;
                            Debug.Log("energy up: " + energyTimer);  //replace with the desired ability display
                            display.GetComponent<Image>().fillAmount = energyTimer / energyMax;
                            //Color oldCol = display.GetComponent<Image>().color;
                            //if (oldCol.a < 1f) {
                                  // float r = oldCol.r + 0.01f;
                                   //float g = oldCol.g + 0.01f;
                                   //float b = oldCol.b + 0.01f;
                                   //float a = oldCol.a;
                                   //display.GetComponent<Image>().color = new Color(r,g,b,a);
                                   //float x = display.localScale.x * 1.005f;
                                   //float y = display.localScale.y * 1.005f;
                                   //float z = display.localScale.z;
                                   //display.localScale = new Vector3(x, y, z);
                            //}
                     }
                     else {chargeTimer.SetActive (false); }
              }
        }

        IEnumerator NotFlying(){
          isFlying = true;
          yield return new WaitForSeconds(flyTime);
          thingOn = false;
          isFlying = false;
        }

}
