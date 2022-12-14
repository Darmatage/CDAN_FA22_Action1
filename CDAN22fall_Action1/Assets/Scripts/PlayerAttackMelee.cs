using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour{

      public Animator anim; //dragged directly into slot
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 80;
      public LayerMask enemyLayers;


      void Update(){
        anim = gameObject.GetComponent<PlayerAnimal>().currentAnim;
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if ((Input.GetAxis("Attack") > 0)&&(GameHandler.currentBeast == "bear")){
                        Attack();
                        anim.SetTrigger ("attack");
                        nextAttackTime = Time.time + 1f / attackRate;
						                 //Debug.Log("I pressed Attack"));
                  }
            }
      }

      void Attack(){
            //animator.SetTrigger ("Melee");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);
                  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
            }
      }

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
}
