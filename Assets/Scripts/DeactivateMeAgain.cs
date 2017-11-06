using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeactivateMeAgain : MonoBehaviour {

    private float delay = 1f;
    public static bool canSpawnCars;
    private float animationTime;

    void Start () {
        canSpawnCars = false;
        //Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length-0.1f);
        StartCoroutine(spawnCars());
   }

    IEnumerator spawnCars()
    {
        yield return new WaitForSeconds(3.5f);
        canSpawnCars = true;
        this.gameObject.SetActive(false);
    }
}
