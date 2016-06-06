using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickCharacter : MonoBehaviour {

    [SerializeField]
    private Sprite pickedGirl;
    [SerializeField]
    private Sprite pickedBoy;
    [SerializeField]
    private Sprite originalGirl;
    [SerializeField]
    private Sprite originalBoy;
    [SerializeField]
    private GameObject girlButton;
    [SerializeField]
    private GameObject boyButton;

    public void PickGirl()
    {
        PlayerPrefs.SetString("gender", "female");

        if(boyButton.GetComponent<Image>().sprite == pickedBoy)
        {
            boyButton.GetComponent<Image>().sprite = originalBoy;
        } 

        girlButton.GetComponent<Image>().sprite = pickedGirl;
    }

    public void PickBoy()
    {
        PlayerPrefs.SetString("gender", "male");

        if (girlButton.GetComponent<Image>().sprite == pickedGirl)
        {
            girlButton.GetComponent<Image>().sprite = originalGirl;
        }

        boyButton.GetComponent<Image>().sprite = pickedBoy;
    }
}
