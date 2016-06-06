using UnityEngine;
using System.Collections;

public class DeactivateMeAgain : MonoBehaviour {

    private float delay = 1f;
    public static bool canSpawnCars;
    private float animationTime;

	// Use this for initialization
	void Start () {
        canSpawnCars = false;
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(spawnCars());
   }

    IEnumerator spawnCars()
    {
        yield return new WaitForSeconds(3.5f);
        canSpawnCars = true;
    }
}
