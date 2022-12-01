using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerClimb : MonoBehaviour {

    //public Animator anim;
    public Rigidbody2D rb;
    public float climbForce = 7f;
    public Transform feet;
    public LayerMask climbLayer;
    //public LayerMask enemyLayer;
    public bool canClimb = false;
    //public int climbTimes = 0;
    public bool isAlive = true;
    //public AudioSource JumpSFX;
	public float feetRange = 1f;

	//bool isBird = false;
	//bool canFly = false;
	//public float groundPos = 0;


    void Start(){
            //animator = gameObject.GetComponent<PlayerAnimal>().curentAnim;
            rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //animator = gameObject.GetComponent<PlayerAnimal>().curentAnim;
		if (GameHandler.currentBeast=="bear"){
			//if ((IsGrounded()) || (jumpTimes <= 1)){
			if (IsClimeable()){
				canClimb = true;
			}
			//else if (jumpTimes >= 1){
			else {
				canClimb = false;
			}
		} else {canClimb = false;}
		
		
		
    if ((Input.GetButtonDown("Jump")) && (canClimb) && (isAlive == true)) {
      Climb();
    }

    }

    public void Climb() {
        //climbTimes += 1;
        rb.velocity = Vector2.up * climbForce;
        // anim.SetTrigger("Jump");
        // JumpSFX.Play();

        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

    public bool IsClimeable() {
        Collider2D climbCheck = Physics2D.OverlapCircle(feet.position, feetRange, climbLayer);
        //Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, feetRange, enemyLayer);
		if (climbCheck != null){
			//groundPos = feet.position.y;
		}
		if ((climbCheck != null)) {
            //Debug.Log("I am trouching climb!");
            //climbTimes = 0;
            return true;
        }
        return false;
    }

}
