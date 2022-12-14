using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackShoot : MonoBehaviour{

      //public Animator animator;
      public Transform firePoint;
      public GameObject projectilePrefab;
      public float projectileSpeed = 10f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
      }

      void Update(){
           if (Time.time >= nextAttackTime){
                //if (Input.GetKeyDown(KeyCode.Space))
                 if ((Input.GetAxis("Attack") > 0)&&(GameHandler.currentBeast == "pigeon")){
                   Debug.Log("i tried to egg");
                        playerFire();
                        nextAttackTime = Time.time + 1f / attackRate;
                        Debug.Log("i shot");
                  }
            }
      }

      void playerFire(){
            //animator.SetTrigger ("Fire");
            Vector2 fwd = (firePoint.position - this.transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeed, ForceMode2D.Impulse);
      }
}
