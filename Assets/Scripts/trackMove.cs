using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trackMove : MonoBehaviour {

	public float speed;
	Vector2 offset;

    public Material phase1;
    public Material phase2;
    public Material phase3;
    public Material phase4;
    public Material phase5;

    void Start()
    {
        switch (uiManager.phase)
        {
            case 1:
                this.gameObject.GetComponent<MeshRenderer>().material = phase1;
                break;
            case 2:
                this.gameObject.GetComponent<MeshRenderer>().material = phase2;
                break;
            case 3:
                this.gameObject.GetComponent<MeshRenderer>().material = phase3;
                break;
            case 4:
                this.gameObject.GetComponent<MeshRenderer>().material = phase4;
                break;
            case 5:
                this.gameObject.GetComponent<MeshRenderer>().material = phase5;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (0, Time.time * speed);

		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
