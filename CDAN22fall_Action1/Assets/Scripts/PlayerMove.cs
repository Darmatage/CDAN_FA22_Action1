using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

      //public Animator animPigeon;
	  //public Animator animBadger;
	  //public Animator animBear;
      public Rigidbody2D rb2D;
      private bool FaceRight = false; // determine which way player is facing.
      public static float runSpeed1 = 10f;
      public static float runSpeed2 = 11f;
      public static float runSpeed3 = 8f;
      public float startSpeed = 10f;
      public bool isAlive = true;
      private Vector3 hMove;
	  
	  public AudioSource pigeonWalk_SFX1;
	  public AudioSource pigeonWalk_SFX2;
	  public AudioSource pigeonWalk_SFX3;
	  public AudioSource WalkSFX;

      void Start(){
           rb2D = transform.GetComponent<Rigidbody2D>();
		   WalkSFX = pigeonWalk_SFX1;
      }

      void Update(){
           //animator = gameObject.GetComponent<PlayerAnimal>().curentAnim;
		   int newSound = Random.Range (1, 3);
		   
           //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
           hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
           if (isAlive == true){
             if (GameHandler.currentBeast=="bear"){
                  transform.position = transform.position + hMove * runSpeed1 * Time.deltaTime;

                  if (Input.GetAxis("Horizontal") != 0){
                  //       animBear.SetBool ("walk", true);
						//if (newSound == 1){WalkSFX = bearWalk_SFX1;}
						//else if (newSound == 2){WalkSFX = bearWalk_SFX2;}
						//else if (newSound == 3){WalkSFX = bearWalk_SFX3;}
						
                        //if (!WalkSFX.isPlaying){
                        //       WalkSFX.Play();
                        //}
                  } else {
                  //      animBear.SetBool ("walk", false);
                        WalkSFX.Stop();
                  }

                  // Turning: Reverse if input is moving the Player right and Player faces left
                 if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                        playerTurn();
                  }
           }
         }
         if (isAlive == true){
           if (GameHandler.currentBeast=="badger"){
                transform.position = transform.position + hMove * runSpeed2 * Time.deltaTime;

                if (Input.GetAxis("Horizontal") != 0){
                //       animBadger.SetBool ("walk", true);
						//if (newSound == 1){WalkSFX = badgerWalk_SFX1;}
						//else if (newSound == 2){WalkSFX = badgerWalk_SFX2;}
						//else if (newSound == 3){WalkSFX = badgerWalk_SFX3;}
						
                        //if (!WalkSFX.isPlaying){
                        //       WalkSFX.Play();
                        //}
                } else {
                //      animBadger.SetBool ("walk", false);
                      WalkSFX.Stop();
                }

                // Turning: Reverse if input is moving the Player right and Player faces left
               if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                      playerTurn();
                }
         }
       }
       if (isAlive == true){
         if (GameHandler.currentBeast=="pigeon"){
              transform.position = transform.position + hMove * runSpeed3 * Time.deltaTime;

              if (Input.GetAxis("Horizontal") != 0){
              //       animPigeon.SetBool ("walk", true);
						if (newSound == 1){WalkSFX = pigeonWalk_SFX1;}
						else if (newSound == 2){WalkSFX = pigeonWalk_SFX2;}
						else if (newSound == 3){WalkSFX = pigeonWalk_SFX3;}
						
                        if (!WalkSFX.isPlaying){
                               WalkSFX.Play();
                        }
              } else {
              //      animPigeon.SetBool ("walk", false);
                    WalkSFX.Stop();
              }

              // Turning: Reverse if input is moving the Player right and Player faces left
             if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                    playerTurn();
              }
       }
     }
      }

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }
      }

      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }



}
