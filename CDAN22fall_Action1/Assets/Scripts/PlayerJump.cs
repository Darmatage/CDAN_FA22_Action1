using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool canJump = false;
    public int jumpTimes = 0;
    public bool isAlive = true;
    //public AudioSource JumpSFX;
	public float feetRange = 1f;

	//bool isBird = false;
	bool canFly = false;
	public static bool flyEnergyEnough = true;
	public float groundPos = 0;


    void Start(){
            anim = gameObject.GetComponent<PlayerAnimal>().currentAnim;
            rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        anim = gameObject.GetComponent<PlayerAnimal>().currentAnim;
        if (GameHandler.currentBeast=="bear"){
            canJump = false;
			canFly = false;
		}
		
		if (GameHandler.currentBeast=="badger"){
			//if ((IsGrounded()) || (jumpTimes <= 1)){
			if (IsGrounded()){
				canJump = true;
			}
			//else if (jumpTimes >= 1){
			else {
				canJump = false;
			}
		} else {canJump = false;}


		if (GameHandler.currentBeast == "pigeon"){
			if (flyEnergyEnough){
				canFly = true;
			}
			else{
				canFly = false;
			}
		} else {canFly = false;}


		if ((Input.GetButtonDown("Jump")) && (canJump) && (isAlive == true)) {
			Jump();
		}

		if ((Input.GetButtonDown("Jump")) && (canFly) && (isAlive == true)) {
			Fly();
		}


    }

    public void Jump() {
        jumpTimes += 1;
        rb.velocity = Vector2.up * jumpForce;
         anim.SetTrigger("jump");
        // JumpSFX.Play();

        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

	public void Fly(){
    rb.velocity = Vector2.up * (jumpForce/2);
    //rb.velocity = Vector2.up * (jumpForce/2);
		StopCoroutine(BirdDrop());
		StartCoroutine(BirdDrop());
	}

	IEnumerator BirdDrop(){
		yield return new WaitForSeconds(0.5f);
		rb.velocity = Vector2.up * (jumpForce/3);
		yield return new WaitForSeconds(0.5f);
		rb.velocity = Vector2.up * (jumpForce/4);
		//yield return new WaitForSeconds(0.5f);
		//rb.velocity = Vector2.up * (jumpForce/5);
		//yield return new WaitForSeconds(0.5f);
		//rb.velocity = Vector2.up * (jumpForce/5);

		yield return new WaitForSeconds(1f);
		canFly = false;
	}


    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, feetRange, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, feetRange, enemyLayer);
		if (groundCheck != null){
			groundPos = feet.position.y;
		}
		if ((groundCheck != null) || (enemyCheck != null)) {
            //Debug.Log("I am trouching ground!");
            jumpTimes = 0;
            return true;
        }
        return false;
    }

}
