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
    public static int phase;
    private bool gameOver;
	private int player;
    private string gender;

    void Start ()
    {
        //if (PlayerPrefs.HasKey("phase"))
        //{
        //    PlayerPrefs.DeleteKey("phase");
        //}
        phase = PlayerPrefs.GetInt("phase", 1);
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
		scoreText.text = Arduino.score.ToString();

        if(gender == "female")
        {
            if(Arduino.life == 0)
                lifeImage.sprite = characters[1];
        }
        else
        {
            if(Arduino.life == 1)
                lifeImage.sprite = characters[3];
            if(Arduino.life == 0)
                lifeImage.sprite = characters[4];
        }

        if (Arduino.life == 0 && Arduino.score < 700)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponentInChildren<Text>().text = Arduino.score.ToString();
        }
        else if (Arduino.life == 0 && Arduino.score > 700)
        {
            Time.timeScale = 0;
            nextLevelPanel.SetActive(true);
            nextLevelPanel.GetComponentInChildren<Text>().text = Arduino.score.ToString();
            switch (phase)
            {
                case 1:
                    if (Arduino.score >= 900)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "1";
                    else if (Arduino.score >= 800 && Arduino.score < 900)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    else if (Arduino.score >= 700 && Arduino.score < 800)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "3";
                    break;
                case 2:
                    if (Arduino.score >= 1200)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "1";
                    else if (Arduino.score >= 1100 && Arduino.score < 1200)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    else if (Arduino.score >= 1000 && Arduino.score < 1100)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "3";
                    break;
                case 3:
                    if (Arduino.score >= 1500)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "1";
                    else if (Arduino.score >= 1400 && Arduino.score < 1500)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    else if (Arduino.score >= 1300 && Arduino.score < 1400)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    break;
                case 4:
                    if (Arduino.score >= 1800)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "1";
                    else if (Arduino.score >= 1700 && Arduino.score < 1800)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    else if (Arduino.score >= 1600 && Arduino.score < 1700)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    break;
                case 5:
                    if (Arduino.score >= 2100)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "1";
                    else if (Arduino.score >= 2000 && Arduino.score < 2100)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    else if (Arduino.score >= 1900 && Arduino.score < 2000)
                        nextLevelPanel.GetComponentsInChildren<Text>()[1].text = "2";
                    break;
            }
        }
	}

	public void Play()
    {
        switch (phase)
        {
            case 1:
                phase = 2;
                break;
            case 2:
                phase = 3;
                break;
            case 3:
                phase = 4;
                break;
            case 4:
                phase = 5;
                break;
        }
        PlayerPrefs.SetInt("phase", phase);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    public void Retry() {
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
