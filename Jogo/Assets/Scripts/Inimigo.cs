using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int hitsToDeath = 3;

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