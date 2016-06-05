using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject[] cars;

    private int carNo;
    private Vector3 cam;
    private float maxPos = 2.2f;
	private float delayTimer = 0.5f;
	private float timer;

	void Start () {
		timer = delayTimer;
        
        // Permite que o carro ajuste seu curso em diferentes resoluções e tipos de tela
        cam = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxPos = -cam.x - 0.5f;
    }
	
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carPos = new Vector3(Random.Range(-maxPos, maxPos),transform.position.y,transform.position.z);
			carNo = Random.Range (0, cars.Length);
			Instantiate (cars[carNo], carPos, transform.rotation);
			timer = delayTimer;
		}
	}
}
