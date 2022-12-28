using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRevealCollider : MonoBehaviour
{
	private GameCharMenu charMenu;
	
	public bool badgerReveal = false;
	public bool pigeonReveal = false;
	
    void Start(){
        charMenu = GameObject.FindWithTag("GameHandler").GetComponent<GameCharMenu>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.transform.parent.tag == "Player"){
			if (badgerReveal){charMenu.showBadger = true;}
			if (pigeonReveal){charMenu.showPigeon = true;}
		}
    }
	
}
