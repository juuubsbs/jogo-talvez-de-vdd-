using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlmet : MonoBehaviour
{
    public meteoro inimigo01; //refencial ao outro objeto 
    private GerenciadorDeJogoMG1 gerenciadorScript;
    private float tempoDecorrido;
    void Start()
    {
        tempoDecorrido = 0f; // jogo inciar com o tempo 0 
        gerenciadorScript = GameObject.Find("GerenciadorDeJogo").GetComponent<GerenciadorDeJogoMG1>(); //pega o script do gerenciador
    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido += Time.deltaTime; //aumentando o tempo
        tempoDecorrido += Random.Range(0.001f, 0.03f); //tempo aleatorio

        if (gerenciadorScript.jogoIniciou && tempoDecorrido >= 1f)
        {
            tempoDecorrido = 0f; //volta pro segundo 0 pra n�o fica mil meteoros doido 

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  //posic�o fora da camera
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);
            Vector2 posicaometeoro = new Vector2(posicaoX, posicaoMaxima.y);// cria meteoro aleatoriamente na parte de cima da camera

            Instantiate(inimigo01, posicaometeoro, Quaternion.identity, transform); // cria um novo meteoro1
            
        }

    }
}
