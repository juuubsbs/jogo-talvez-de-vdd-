using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int hitsToDeath = 3;
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
            Vector3 direcao = (player.position - transform.position).normalized;
            transform.position += direcao * velocidade * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
            LevarDano();
        }
    }

    private void LevarDano()
    {
        hitsToDeath--;
        if (hitsToDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}