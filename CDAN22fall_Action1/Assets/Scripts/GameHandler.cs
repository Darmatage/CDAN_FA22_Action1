using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

	public static int Lives = 5;
	public int maxLives = 5;
	public GameObject lifeHeart1;
	public GameObject lifeHeart2;
	public GameObject lifeHeart3;
	public GameObject lifeHeart4;
	public GameObject lifeHeart5;


	public static string currentBeast = "bear";
	private GameObject player;
	public static int playerHealth = 100;
	public int StartPlayerHealth = 100;
	public GameObject healthText;

	public static int gotTokens = 0;
	public GameObject tokensText;

	public bool isDefending = false;

	public static bool stairCaseUnlocked = false;
	//this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

	public static bool GameisPaused = false;
	public GameObject pauseMenuUI;
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;

        void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }

      private string sceneName;

      void Start(){
            player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            pauseMenuUI.SetActive(false);
            GameisPaused = false;
            updateStatsDisplay();
      }

      public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
            updateStatsDisplay();
      }


	public void playerGetHit(int damage){
		string sceneName = SceneManager.GetActiveScene().name;
		if (isDefending == false){
			playerHealth -= damage;
			if (playerHealth >=0){
				updateStatsDisplay();
			}
			if (damage > 0){
				player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation
			}
		}

		if (playerHealth > StartPlayerHealth){
			playerHealth = StartPlayerHealth;
			updateStatsDisplay();
		}

		if ((playerHealth <= 0)&&(sceneName != "EndLose")){
			if (Lives <= 0){
				playerHealth = 0;
				updateStatsDisplay();
				playerDies();
			} else {
				if (Lives > 1){
					playerHealth = StartPlayerHealth;
				}
				updateStatsDisplay();
				UpdateLives(-1, "down");
			}
		}
	}

	public void UpdateLives(int lifeChange, string changeDir){
		Lives += lifeChange;
		PlayerRespawn respawn = player.GetComponent<PlayerRespawn>();
		if (changeDir == "down"){
			if (lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(false); respawn.RespawnHearts();}
			else if (lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(false); respawn.RespawnHearts();}
			else if (lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(false); respawn.RespawnHearts();}
			else if (lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(false); respawn.RespawnHearts();}
			else if (lifeHeart1.activeInHierarchy){lifeHeart1.SetActive(false);}
		} 
		else if (changeDir == "up"){
			if (!lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(true);}
			else if (!lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(true);}
			else if (!lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(true);}
			else if (!lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(true);}
		}
	}


	public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "" + playerHealth;

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "GOLD: " + gotTokens;
	}

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
        //    player.GetComponent<PlayerMove>().isAlive = false;
        //    player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
            playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}
