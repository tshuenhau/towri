using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Controller : MonoBehaviour
{
    [SerializeField]GameObject gameOverScreen;
    [SerializeField]GameObject startScreen;
    [SerializeField]GameObject HighScoreText;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip lossSFX;
    [SerializeField] AudioClip tooSoonSFX;
    [SerializeField] Button continueButton;
    int speedIncrease = 5;
    int currentSceneIndex;
    AudioSource audioSource;
    GameSession gameSession;
    Planet planet;
    Spawner spawner;
    Roof roof;
    // Start is called before the first frame update
    void Awake(){
        DontDestroyOnLoad(successSFX);
        DontDestroyOnLoad(lossSFX);
        DontDestroyOnLoad(tooSoonSFX);
        spawner = FindObjectOfType<Spawner>();
        planet = FindObjectOfType<Planet>();
        gameSession = FindObjectOfType<GameSession>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        roof = FindObjectOfType<Roof>();
        audioSource = GetComponent<AudioSource>();

    }
    void Start()
    {
        gameOverScreen.SetActive(false);
        if(gameSession.getInitial() == true){
            Time.timeScale = 0;
            startScreen.SetActive(true);
            gameSession.toggleInitial();
        }
        else{
            startScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefsController.GetContinues() > 0){
            continueButton.interactable = true;
        }
        else{
            continueButton.interactable = false;
        }        
    }

    public void Play(){
        startScreen.SetActive(false);
        roof.toggleStart(false);
        Time.timeScale = 1;
    }

    public void Continue(){
        gameSession.AddToContinuesUsed();
        gameOverScreen.SetActive(false);
        audioSource.Stop();
        PlayerPrefsController.UpdateContinues(-1);
        PlayerPrefs.Save();
        Time.timeScale = 1;
    }
    public void TryAgain(){
        gameSession.ResetGame();
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }
    public void HandleSuccess(Satelite satelite){
        audioSource.PlayOneShot(successSFX, 0.3f);
        planet.ChangeDirection();
        planet.ChangeSpeed(speedIncrease);
        spawner.SpawnSatelite(-planet.GetDirection());
        gameSession.AddToScore(1);
        int currScore = gameSession.GetScore();
        if(currScore > PlayerPrefsController.GetHighScore()){
            PlayerPrefsController.UpdateHighScore(currScore);
        }
        satelite.destroy();
    }   
    public void GameOver(){
        Time.timeScale = 0; 
        audioSource.PlayOneShot(lossSFX, 0.3f);
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over!";
        gameOverScreen.SetActive(true);
    }
    public void TooSoon(){
        audioSource.PlayOneShot(tooSoonSFX);
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "Too Soon!";
        gameOverScreen.SetActive(true);
    }

}
