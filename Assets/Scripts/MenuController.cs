using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class MenuController : SceneController {

    public GameObject menuPanel;

    SerialPort port = new SerialPort("COM3", 9600);

    void Start()
    {
        port.Open();
        port.ReadTimeout = 1;

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (port.IsOpen)
        {
            // Executar ação aqui. Pimba!
        }
    }

    public void DisablePauseAnimation(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
        StartCoroutine(DisplayMenu());
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

    IEnumerator DisplayMenu()
    {
        yield return new WaitForSeconds(0.5f);
        menuPanel.SetActive(true);
    }
}
