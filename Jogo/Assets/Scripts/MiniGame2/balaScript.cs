using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaScript : MonoBehaviour
{
    [SerializeField] float tempoParaDestruir = 6f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Destroi o objeto após 6 segundos
        Destroy(gameObject, tempoParaDestruir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método chamado quando a bala colide com outro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Verifica se a colisão foi com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroi a bala ao colidir com o jogador
            Destroy(gameObject);
        }
    }
}