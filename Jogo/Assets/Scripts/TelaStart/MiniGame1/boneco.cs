using System.Collections.Generic;
using UnityEngine;

public class Boneco : MonoBehaviour
{
    public float speed; // Velocidade de movimento do boneco
    private Rigidbody2D rig; // Componente Rigidbody2D para controlar a física do boneco
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer para alterar a cor do objeto
    private int vidaAnterior; // Armazena o valor anterior de "Vida"
    private float danoTimer; // Tempo restante para o efeito de dano
    private Color corOriginal; // Cor original do objeto

    float direction; // Direção do movimento horizontal

    void Start()
    {
        PlayerPrefs.SetInt("Vida", 3); // Inicializa a vida no PlayerPrefs
        vidaAnterior = PlayerPrefs.GetInt("Vida"); // Armazena o valor inicial da vida
        rig = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtém o componente SpriteRenderer
        corOriginal = spriteRenderer.color; // Salva a cor original
        danoTimer = 0f; // Inicializa o timer
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal"); // Obtém a direção do movimento horizontal a partir da entrada do usuário

        // Verifica se houve alteração no valor de "Vida"
        int vidaAtual = PlayerPrefs.GetInt("Vida");
        if (vidaAtual != vidaAnterior)
        {
            // Muda a cor para vermelho e define o timer
            spriteRenderer.color = Color.red;
            danoTimer = 0.1f; // Define o tempo do efeito de dano
            vidaAnterior = vidaAtual; // Atualiza o valor de vida anterior
        }

        // Verifica se o temporizador está ativo
        if (danoTimer > 0)
        {
            danoTimer -= Time.deltaTime; // Reduz o tempo restante
            if (danoTimer <= 0)
            {
                // Restaura a cor original após o tempo
                spriteRenderer.color = corOriginal;
            }
        }
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y); // Aplica a velocidade ao Rigidbody2D para mover o boneco horizontalmente
    }
}
