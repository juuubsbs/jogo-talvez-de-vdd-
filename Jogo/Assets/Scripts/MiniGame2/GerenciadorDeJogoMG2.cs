using UnityEngine;

public class GerenciadorDeJogo : MonoBehaviour
{
    public bool jogoIniciou = false;
    public GameObject Vida;

    void Start()
    {
        
    }

    void Update()
    {
        ativaVida();
    }

    void ativaVida()
    {
        if (Vida != null && Mathf.Abs(Vida.transform.position.y) < 0.1f)
        {
            Vida.SetActive(true); // Ativa o objeto Vida
        }
    }
}