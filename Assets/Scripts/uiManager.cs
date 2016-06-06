using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour {
	
	public Button[] buttons;
	public Text scoreText;
    public GameObject pausePanel;

    private bool gameOver;
	private int score;
    private int player;

	void Start ()
    {
        Time.timeScale = 1;
		gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	void Update () {
		scoreText.text = "Score: " + score;
	}

	void scoreUpdate(){
		if (gameOver == false) {
			score += 1;
		}
	}

	public void gameOverActivated(){
		gameOver = true;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
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
