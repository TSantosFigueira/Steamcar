using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoMenu : MonoBehaviour
{

    public GameObject[] UiElements;
    private int currentIndex;

    void Awake()
    {
        ActivateElement(0);
        currentIndex = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("RightButton"))
        {
            currentIndex++;

            if (currentIndex >= UiElements.Length)
            {
                currentIndex = 0;
            }

            ActivateElement(currentIndex);
        }

        else if (Input.GetButtonDown("LeftButton"))
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = UiElements.Length - 1;
            }

            ActivateElement(currentIndex);
        }

        // Ativar aqui com o botão no controle para executar a ação. Exemplo, carregar próxima página. Detalhe: o evento deve estar no botão.

        //if (Input.GetButton("Pimba"))
        //{
        //    UiElements[currentIndex].GetComponent<Button>().onClick.Invoke();
        //}
    }

    // Ativa o elemento desejado e desativa todo o resto
    void ActivateElement(int index)
    {
        if (UiElements.Length > 0 && index <= UiElements.Length)
        {
            UiElements[index].GetComponent<Button>().interactable = true;

            for (int i = 0; i < UiElements.Length; i++)
            {
                if (i != index)
                {
                    UiElements[i].GetComponent<Button>().interactable = false;
                }
            }
        }

        else
        {
            Debug.LogError("Não há elementos na lista de UI. Verifique o MenuManager");
        }
    }
}
