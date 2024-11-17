using UnityEngine;

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
        }
    }

    public void AlterarVida(int novaVida)
    {
        vidaAtual = novaVida;
        PlayerPrefs.SetInt("Vida", vidaAtual);
        PlayerPrefs.Save();
        AtualizarCoracoes();
    }

    // Atualiza a visibilidade dos corações com base na vida atual
    private void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            coracoes[i].SetActive(i < vidaAtual);
        }
    }
}