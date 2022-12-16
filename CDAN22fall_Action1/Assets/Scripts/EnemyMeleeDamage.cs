using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {
       private Renderer rend;
       //public Animator anim;
       public GameObject healthLoot;
       public int maxHealth = 100;
       public int currentHealth;

	public float knockBackForce = 40f; 


       void Start(){
              rend = GetComponentInChildren<Renderer> ();
              //anim = GetComponentInChildren<Animator> ();
              currentHealth = maxHealth;
       }

       public void TakeDamage(int damage){
			knockBack();
			currentHealth -= damage;
			//rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
			//StartCoroutine(ResetColor());
			//anim.SetTrigger ("Hurt");
			if (currentHealth <= 0){
				Die();
			}
       }

	public void knockBack(){
		Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
		
		Rigidbody2D pushRB = gameObject.GetComponent<Rigidbody2D>();
		Vector2 moveDirectionPush = pushRB.transform.position - playerPos;
		pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
		StartCoroutine(EndKnockBack(pushRB)); 
		
		
	}

      IEnumerator EndKnockBack(Rigidbody2D enemyRB){
              yield return new WaitForSeconds(0.2f);
              enemyRB.velocity= new Vector3(0,0,0);
       } 


       void Die(){
              Instantiate (healthLoot, transform.position, Quaternion.identity);
              //anim.SetBool ("isDead", true);
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.5f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
       }

       IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
}
