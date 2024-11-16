using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoro : MonoBehaviour
{
    public Rigidbody2D rigidbody2; //associar o meteoro ao codigo

    public float velocidademaxima; 
    public float velocidademinima;

    private float velocidadeY;


    void Start()
    {
        
        this.velocidadeY = Random.Range(this.velocidademaxima , velocidademaxima); //pega velocidade aleatoria entre maximo e minimo ao iniciar 

    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody2.velocity = new Vector2( 0 , -velocidadeY ); //meteoro ira receber a velociade aleatoria da linha 18
    }
}
