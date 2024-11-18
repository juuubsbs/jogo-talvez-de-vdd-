using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hitsToDeath = 3; // Número de acertos necessários para destruir o inimigo
    [SerializeField] private float velocidade = 2f; // Velocidade do inimigo
    private Transform player; // Referência ao transform do player

    private void Start()
    {
        // Encontra o player na cena
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Se o player foi encontrado, segue o player
        if (player != null)
        {
            Vector3 direcao = (player.position - transform.position).normalized; // Calcula a direção para o player
            transform.position += direcao * velocidade * Time.deltaTime; // Move o inimigo na direção do player
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
        hitsToDeath--; // Reduz o número de acertos necessários para destruir o inimigo
        if (hitsToDeath <= 0)
        {
            Destroy(gameObject); // Destrói o inimigo se o número de acertos for zero ou menor
        }
    }
}