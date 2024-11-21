using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hitsToDeath = 3; // Número de acertos necessários para destruir o inimigo
    [SerializeField] private float velocidade = 2f; // Velocidade do inimigo
    private Transform player; // Referência ao transform do player
    [SerializeField] private AudioClip hitSound; // Som a ser tocado quando o inimigo é atingido
    [SerializeField] private AudioClip deathSound; // Som a ser tocado quando o inimigo morre
    private AudioSource audioSource; // Componente de áudio
    private SpriteRenderer spriteRenderer; // Componente de SpriteRenderer
    private Color originalColor; // Cor original do sprite
    private float colorChangeTime = 0.1f; // Tempo que o inimigo permanece vermelho
    private float colorChangeTimer; // Temporizador para controlar a mudança de cor

    private void Start()
    {
        // Encontra o player na cena
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Obtém o componente de áudio
        audioSource = GetComponent<AudioSource>();
        // Obtém o componente de SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Salva a cor original do sprite
        originalColor = spriteRenderer.color;
        // Define o volume do áudio com base no valor salvo em PlayerPrefs, padrão 0.5
        audioSource.volume = PlayerPrefs.GetFloat("volume", 0.5f);
    }

    private void Update()
    {
        // Se o player foi encontrado, segue o player
        if (player != null)
        {
            Vector3 direcao = (player.position - transform.position).normalized; // Calcula a direção para o player
            transform.position += direcao * velocidade * Time.deltaTime; // Move o inimigo na direção do player
        }

        // Verifica se o temporizador de mudança de cor está ativo
        if (colorChangeTimer > 0)
        {
            colorChangeTimer -= Time.deltaTime;
            if (colorChangeTimer <= 0)
            {
                spriteRenderer.color = originalColor; // Volta à cor original
            }
        }
    }
    private void contadorDeKills()
    {
        // Encontra o player na cena
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Obtém o script Princesa no objeto player
            Princesa princesaScript = player.GetComponent<Princesa>();
            if (princesaScript != null)
            {
                // Incrementa a variável kills
                princesaScript.kills++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com um objeto com a tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject); // Destrói a bala
            LevarDano(); // Chama o método para levar dano
        }
    }

    private void LevarDano()
    {
        hitsToDeath--;
        if (hitsToDeath <= 0)
        {
            PlayDeathSound(); // Toca o som de morte
            contadorDeKills(); // Incrementa o contador de kills
            Destroy(gameObject); // Destroi o inimigo se os acertos forem suficientes
        }
        else
        {
            PlayHitSound(); // Toca o som de acerto
            FlashVermelho(); // Muda a cor para vermelho
        }
    }

    private void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    private void PlayDeathSound()
    {
        if (audioSource != null && deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, audioSource.volume);
        }
    }

    private void FlashVermelho()
    {
        spriteRenderer.color = Color.red; // Muda a cor para vermelho
        colorChangeTimer = colorChangeTime; // Inicia o temporizador de mudança de cor
    }
}