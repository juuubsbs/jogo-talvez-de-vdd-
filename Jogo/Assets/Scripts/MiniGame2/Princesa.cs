using UnityEngine;

public class Princesa : MonoBehaviour
{
    public GameObject gerenciadorDeJogoObj; // Referência ao objeto GerenciadorDeJogoMG2
    private GerenciadorDeJogoMG2 gerenciadorDeJogo;
    [SerializeField] private float velocidadeHorizontal = 3.5f; // Variável pública para controlar a velocidade horizontal
    [SerializeField] private float velocidadeVertical = 1f; // Variável pública para controlar a velocidade vertical
    public int vida = 0; // Vida da personagem
    public int kills = 0; // Variável pública para armazenar o número de kills
    public AudioClip somDeDano; // Som de dano
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer
    private Color corOriginal; // Cor original do sprite
    private float danoTimer = 0f; // Temporizador para controlar a duração da cor vermelha

    private int colisaoContador = 0; // Contador de colisões com inimigos

    void Start()
    {
        // Obtém a referência ao script GerenciadorDeJogo
        gerenciadorDeJogo = gerenciadorDeJogoObj.GetComponent<GerenciadorDeJogoMG2>();
        // Obtém o componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Salva a cor original do sprite
        corOriginal = spriteRenderer.color;
        vida = PlayerPrefs.GetInt("Vida", 3); // Carrega a vida do PlayerPrefs
        // Configura o Rigidbody2D como Kinematic
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Kinematic;
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
            float clampedX = Mathf.Clamp(transform.position.x, -22f, 22f);
            float clampedY = Mathf.Clamp(transform.position.y, -0.69f, 3.5f);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }

        // Verifica o temporizador de dano
        if (danoTimer > 0)
        {
            danoTimer -= Time.deltaTime;
            if (danoTimer <= 0)
            {
                // Restaura a cor original
                spriteRenderer.color = corOriginal;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            colisaoContador++; // Incrementa o contador de colisões
            Destroy(other.gameObject); // Destroi o inimigo
            if (colisaoContador >= 2)
            {
                vida--;
                PlayerPrefs.SetInt("Vida", vida); // Salva a vida do jogador
                colisaoContador = 0; // Reseta o contador após perder 1 de vida
                float volume = PlayerPrefs.GetFloat("volume", 1f); // Padrão: volume máximo
                // Toca o som de dano na posição da princesa
                AudioSource.PlayClipAtPoint(somDeDano, transform.position, volume);

                // Muda a cor do sprite para vermelho
                spriteRenderer.color = Color.red;
                // Define o temporizador de dano
                danoTimer = 0.1f;
            }
        }
    }
}