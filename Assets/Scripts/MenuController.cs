﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : SceneController {

    public GameObject menuPanel;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void DisablePauseAnimation(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
        menuPanel.SetActive(true);
    }

    public void EnablePauseAnimation(Animator anim)
    {
        anim.SetBool("IsDisplayed", true);
        menuPanel.SetActive(false);
    }

    public override void Play()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
}