using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour{
	
	public float destroyTime=1f;
	
    void Start(){
        StartCoroutine(destroyPS());
    }

    IEnumerator destroyPS(){
        yield return new WaitForSeconds(destroyTime);
		Destroy(gameObject);
    }
	
}
