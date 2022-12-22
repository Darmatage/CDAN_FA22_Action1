using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CrateMove : MonoBehaviour {

       void OnCollisionExit2D(Collision2D colExt){
              gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
              if ((colExt.gameObject.GetComponent<Rigidbody2D>() != null) && (colExt.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)){
                        colExt.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
						
						//Vector3 v3 = rigidbody.velocity;
						//v3.x = 0.0f;
						//v3.z = 0.0f;
						//rigidbody.velocity = v3;
						
						
                }
        }

}
