using UnityEngine;
using UnityEngine.SceneManagement; // Inclua a biblioteca SceneManagement

public class Vida : MonoBehaviour
{
    [SerializeField] private GameObject[] coracoes; // Array de GameObjects que representam os corações de vida
    public int vidaAtual;

    void Start()
    {
        // Carrega a vida do PlayerPrefs ao iniciar o jogo
        vidaAtual = PlayerPrefs.GetInt("Vida", 3); // Valor padrão é 3
        AtualizarCoracoes();
    }

    void Update()
    {
        // Verifica se a vida foi alterada
        int novaVida = PlayerPrefs.GetInt("Vida", 3);
        if (novaVida != vidaAtual)
        {
            vidaAtual = novaVida;
            AtualizarCoracoes();

            // Verifica se a vida chegou a 0
            if (vidaAtual <= 0)
            {
                // Carrega a cena "GameOver"
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void AtualizarCoracoes()
    {
        // Atualiza a exibição dos corações de vida
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].SetActive(i < vidaAtual);
        }
    }
}