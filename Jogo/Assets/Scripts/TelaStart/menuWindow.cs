using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//script pra controlar o trigger pra tecla de menu
public class menuWindow : MonoBehaviour
{

    private Button button;
    private GameObject painel;
    private Button fecha;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        painel = GameObject.Find("Modal Window");

        painel.SetActive(false);
        button.onClick.AddListener(ChamaMenu);
    }

    // função pra chamar o menu
    void ChamaMenu(){
        painel.SetActive(true);
    }
}
