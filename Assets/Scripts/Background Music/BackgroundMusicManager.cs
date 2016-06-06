using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicManager : MonoBehaviour
{

    public AudioSource music;
    public static GameObject musicManager;
    public Sprite buttonOn, buttonOff;

    private GameObject audioButton;

    void Start()
    {
        //music = GetComponent<AudioSource>();
        audioButton = GameObject.FindGameObjectWithTag("SoundButton");

        string music_state = PlayerPrefs.GetString("music", "on");
        music.loop = true;

        if (GameObject.FindGameObjectsWithTag("DontDestroy").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("DontDestroy")[0]);
        }

        if (music_state == "on")
        {
            music.Play();
            audioButton.GetComponent<Image>().sprite = buttonOn;
            musicManager = gameObject;
        }
        else
        {
            music.Play();
            music.Pause();
            audioButton.GetComponent<Image>().sprite = buttonOff;
        }
    }

    public void pressed()
    {
        if (music.isPlaying)
        {
            music.Pause();
            audioButton.GetComponent<Image>().sprite = buttonOff;
            PlayerPrefs.SetString("music", "off");
        }

        else
        {
            music.UnPause();
            audioButton.GetComponent<Image>().sprite = buttonOn;
            PlayerPrefs.SetString("music", "on");
        }
    }
}
