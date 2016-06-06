using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    public static float time;
    private Text timeText;

	// Use this for initialization
	void Start () {
        time = 63f;
        timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f0");

        if(time <= 0)
        {
            time = 0;
        }
	}
}
