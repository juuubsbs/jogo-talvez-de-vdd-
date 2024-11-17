using UnityEngine;

public class Princesa : MonoBehaviour
{
    private GerenciadorDeJogo gerenciadorDeJogo;
    [SerializeField] private float velocidadeHorizontal = 3.5f; // Variável pública para controlar a velocidade horizontal
    [SerializeField] private float velocidadeVertical = 1f; // Variável pública para controlar a velocidade vertical

    void Start()
    {
        // Obtém a referência ao script GerenciadorDeJogo
        gerenciadorDeJogo = FindObjectOfType<GerenciadorDeJogo>();
    }

    void Update()
    {
        // Verifica se o jogo iniciou
        if (gerenciadorDeJogo != null && gerenciadorDeJogo.jogoIniciou)
        {
            // Inicializa o movimento
            float movimentoHorizontal = 0f;
            float movimentoVertical = 0f;

            // Verifica as teclas pressionadas
            if (Input.GetKey(KeyCode.A))
            {
                movimentoHorizontal = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movimentoHorizontal = 1f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movimentoVertical = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movimentoVertical = -1f;
            }

            // Aplica o movimento
            Vector3 movimento = new Vector3(movimentoHorizontal * velocidadeHorizontal, movimentoVertical * velocidadeVertical, 0f);
            transform.Translate(movimento * Time.deltaTime);

            // Limita a posição da personagem
            float clampedX = Mathf.Clamp(transform.position.x, -16f, 16f);
            float clampedY = Mathf.Clamp(transform.position.y, -2f, 3.5f);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}