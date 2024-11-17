using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FecharScript : MonoBehaviour
{
    private Button button;
    private GameObject painel;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        painel = GameObject.Find("Modal Window");

        button.onClick.AddListener(ChamaMenu);
    }

    // função pra chamar o menu
    void ChamaMenu(){
        painel.SetActive(false);
        Time.timeScale = 1;

    }
}
