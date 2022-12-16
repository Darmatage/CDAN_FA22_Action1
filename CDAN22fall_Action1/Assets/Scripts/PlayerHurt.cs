using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{

      public Animator anim;
      public Rigidbody2D rb2D;

      void Start(){
           anim = gameObject.GetComponent<PlayerAnimal>().currentAnim;
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

void Update(){
  anim = gameObject.GetComponent<PlayerAnimal>().currentAnim;
}

      public void playerHit(){
            anim.SetTrigger ("hurt");
      }

      public void playerDead(){
            rb2D.isKinematic = true;
            anim.SetTrigger ("KO");
      }
}
