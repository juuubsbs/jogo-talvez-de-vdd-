using UnityEngine;

public class GerenciadorDeJogo : MonoBehaviour
{
    public bool jogoIniciou = false;

    void Start()
    {
       
    }

    void Update()
    {
        if(jogoIniciou)
        {
            PlayerPrefs.SetInt("Vida", 2);
        }
    }
}