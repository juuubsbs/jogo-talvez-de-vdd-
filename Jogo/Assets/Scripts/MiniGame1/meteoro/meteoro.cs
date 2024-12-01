using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meteoro : MonoBehaviour
{
    // Vida da princesa/jogador
    public int vidaPrincesa;
    public GerenciadorDeJogoMG1 gerenciadorDeJogoMG1;
    // Áudio a ser tocado quando o jogador sofre dano
    public AudioClip somDeDano;

    // Componente Rigidbody2D associado ao meteoro, usado para aplicar física
    public Rigidbody2D rigidbody2;

    // Velocidade máxima que o meteoro pode atingir
    public float velocidademaxima = 10;

    // Velocidade mínima que o meteoro pode atingir
    public float velocidademinima = 5;

    // Velocidade atual no eixo Y, que será sorteada dentro do intervalo mínimo e máximo
    private float velocidadeY;

    // Método chamado ao iniciar o objeto
    void Start()
    {
        // Carrega o valor de "Vida" armazenado no PlayerPrefs, com valor padrão 3 caso não exista
        vidaPrincesa = PlayerPrefs.GetInt("Vida", 3);
        gerenciadorDeJogoMG1 = FindObjectOfType<GerenciadorDeJogoMG1>();
        // Sorteia uma velocidade aleatória para o meteoro entre os valores mínimos e máximos
        velocidadeY = Random.Range(velocidademaxima, velocidademaxima);
    }

    // Método chamado a cada frame
    void Update()
    {
        // Define a velocidade do meteoro no eixo Y (descendo verticalmente)
        rigidbody2.velocity = new Vector2(0, -velocidadeY);
    }

    // Método chamado quando o meteoro colide com outro objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto com o qual colidiu possui a tag "Player"
        if (other.CompareTag("Player"))
        {
            gerenciadorDeJogoMG1.totalHits++; // Incrementa o contador de colisões 

            if (gerenciadorDeJogoMG1.totalHits >= 3)
            {
                vidaPrincesa--;
                // Atualiza o valor de "Vida" no PlayerPrefs
                PlayerPrefs.SetInt("Vida", vidaPrincesa);
                float volume = PlayerPrefs.GetFloat("volume", 1f); // Padrão: volume máximo
                // Reproduz o som de dano na posição do meteoro
                AudioSource.PlayClipAtPoint(somDeDano, transform.position, volume);
                gerenciadorDeJogoMG1.totalHits = 0; // Reseta o contador de colisões
            }
            Destroy(gameObject); // Destroi o meteoro após a colisão
        }
    }
}
