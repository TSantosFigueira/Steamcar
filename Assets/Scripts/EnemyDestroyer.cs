using UnityEngine;
using System.Collections;

public class EnemyDestroyer : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
    {
		if (col.gameObject.tag == "Enemy Car" || col.gameObject.tag == "Droid") {
			Destroy (col.gameObject);
		}
	}
}
