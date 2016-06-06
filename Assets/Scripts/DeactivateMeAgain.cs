using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeactivateMeAgain : MonoBehaviour {

    private float delay = 1f;
    public static bool canSpawnCars;
    private float animationTime;

    public Sprite phase1Sprite;
    public Sprite phase2Sprite;
    public Sprite phase3Sprite;
    public Sprite phase4Sprite;
    public Sprite phase5Sprite;

    void Start () {
        switch (uiManager.phase)
        {
            case 1:
                this.gameObject.GetComponent<Image>().sprite = phase1Sprite;
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = phase2Sprite;
                break;
            case 3:
                this.gameObject.GetComponent<Image>().sprite = phase3Sprite;
                break;
            case 4:
                this.gameObject.GetComponent<Image>().sprite = phase4Sprite;
                break;
            case 5:
                this.gameObject.GetComponent<Image>().sprite = phase5Sprite;
                break;
        }

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
