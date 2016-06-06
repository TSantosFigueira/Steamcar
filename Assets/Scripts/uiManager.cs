using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour {
	
	public Text scoreText;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public Image lifeImage;
    public Sprite[] characters = new Sprite[5];
    private bool gameOver;
	private int player;
    private string gender;

    void Start ()
    {
        Time.timeScale = 1;
        gender = PlayerPrefs.GetString("gender", "female");
		gameOver = false;

        if(gender == "female")
        {
            lifeImage.sprite = characters[0];
        }
        else
        {
            lifeImage.sprite = characters[2];
        }
	}
	
	void Update () {
		scoreText.text = carController.score.ToString();

        if(gender == "female")
        {
            if(carController.life == 0)
                lifeImage.sprite = characters[1];
        }
        else
        {
            if(carController.life == 1)
                lifeImage.sprite = characters[3];
            if(carController.life == 0)
                lifeImage.sprite = characters[4];
        }

        if(carController.life == 0 && carController.score < 700)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponentInChildren<Text>().text = carController.score.ToString();
        }else if(carController.life == 0 && carController.score > 700)
        {
            Time.timeScale = 0;
            nextLevelPanel.SetActive(true);
            nextLevelPanel.GetComponentInChildren<Text>().text = carController.score.ToString();
            if(carController.score >= 700 && carController.score < 800)
               nextLevelPanel.GetComponentInChildren<Text>().text = "3";
            else if(carController.score >= 800 && carController.score < 900)
                nextLevelPanel.GetComponentInChildren<Text>().text = "2";
            else if (carController.score >= 900)
                nextLevelPanel.GetComponentInChildren<Text>().text = "1";
        }
	}

	public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }			
		else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }		
	}
	
	public void Menu(){
        SceneManager.LoadScene("Main Menu");
	}

	public void Exit(){
		Application.Quit ();
	}
}
