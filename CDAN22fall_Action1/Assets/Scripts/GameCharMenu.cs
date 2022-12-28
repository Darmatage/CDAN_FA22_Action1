using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCharMenu : MonoBehaviour
{
	public GameObject bearButton;
	public GameObject badgerButton;
	public GameObject pigeonButton;
	public GameObject bearBack;
	public GameObject badgerBack;
	public GameObject pigeonBack;
	private PlayerAnimal player;
	
	public bool showBadger = true;
	public bool showPigeon = true;
	
	
	void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<PlayerAnimal>();
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "Tutorial"){
			showBadger = false; showPigeon = false;
		}
	}
	

    void Update(){
        if (GameHandler.currentBeast=="bear"){
			bearButton.SetActive(false);
			bearBack.SetActive(true);
		} 
		else {
			bearButton.SetActive(true);
			bearBack.SetActive(false);
			
		} 
		
		if (showBadger == true){
			if (GameHandler.currentBeast=="badger"){
				badgerButton.SetActive(false);
				badgerBack.SetActive(true);
			
			} 
			else {
				badgerButton.SetActive(true);
				badgerBack.SetActive(false);
			}
		} else {badgerButton.SetActive(false); badgerBack.SetActive(false);} 			
		
		if (showPigeon == true){
			if (GameHandler.currentBeast=="pigeon"){
				pigeonButton.SetActive(false);
				pigeonBack.SetActive(true);
			} 
			else {
				pigeonButton.SetActive(true);
				pigeonBack.SetActive(false);
			}
		} else {pigeonButton.SetActive(false); pigeonBack.SetActive(false);} 
    }
	
	public void doBear(){
		player.choiceAnimal = 1;
        player.WhichAnimal(true);
	}
	
	public void doBadger(){
		player.choiceAnimal = 2;
        player.WhichAnimal(true);
	}
	
	public void doPigeon(){
		player.choiceAnimal = 3;
        player.WhichAnimal(true);
	}
	
	
}
