using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlmet : MonoBehaviour
{
    public meteoro inimigo01; //refencial ao outro objeto 
    private float tempoDecorrido;
    void Start()
    {
        this.tempoDecorrido = 0f; // jogo inciar com o tempo 0 
    }

    // Update is called once per frame
    void Update()
    {
        this.tempoDecorrido += Time.deltaTime; //aumentando o tempo 
        if (this.tempoDecorrido >= 1f) //aumenta 1 segundo 
        {
            this.tempoDecorrido = 0f; //volta pro segundo 0 pra não fica mil meteoros doido 

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  //posicão fora da camera
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x); 
            Vector2 posicaometeoro = new Vector2(posicaoX, posicaoMaxima.y);// cria meteoro aleatoriamente na parte de cima da camera

            Instantiate(this.inimigo01, posicaometeoro, Quaternion.identity); // cria um novo meteoro
                                        

        
        }

    }
}
