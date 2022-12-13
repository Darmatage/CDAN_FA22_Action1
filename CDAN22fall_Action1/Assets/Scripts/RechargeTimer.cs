using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RechargeTimer : MonoBehaviour {
       public float energyMax =5f;       //set the number of seconds here (both floats can be static)
       private float energyTimer = 0f;
       public bool thingOn = false;

      void Start(){
           energyTimer = energyMax;
      }

      void Update(){
            if (Input.GetKeyDown("1")){
                  thingOn = !thingOn;           //reverse the bool, so keypress is a toggle
            }
      }

       void FixedUpdate(){
            if (thingOn == true){
                  energyTimer -= 0.01f;
                  Debug.Log("energy down: " + energyTimer);  //replace with the desired ability display
                  if (energyTimer <= 0){
                        thingOn = false;                                   // time has run out
                  }
             } else if ((thingOn == false) && (energyTimer < energyMax)) {
                  energyTimer += 0.01f;
                  Debug.Log("energy up: " + energyTimer);  //replace with the desired ability display
             }
       }
}
