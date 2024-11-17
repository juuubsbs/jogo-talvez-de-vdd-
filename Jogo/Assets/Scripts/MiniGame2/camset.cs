using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camset : MonoBehaviour
{
    public GameObject alvo; // Referência ao objeto alvo
    public float vSuave = 0.01f; // Velocidade de suavização
    public float disMax = 5f; // Distância máxima para a câmera seguir
    private GerenciadorDeJogo gerenciadorDeJogo; // Referência ao script GerenciadorDeJogo
    [SerializeField] private GameObject vida; // Referência ao script Vida
    void Start()
    {
        // Obtém a referência ao script GerenciadorDeJogo
        gerenciadorDeJogo = FindObjectOfType<GerenciadorDeJogo>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        if (gerenciadorDeJogo.jogoIniciou) // Verifica se a variável PosicaoInicialJogo é verdadeira
        {
            MoverCameraYZero(); // Chama a função para mover a câmera para y = 0
        }

        Follow(); // Chama a função Follow a cada frame 
    }

    void Follow()
    {
        if (gerenciadorDeJogo.jogoIniciou) // Se a variável PosicaoInicialJogo for falsa
        {
            Vector3 posicaoAlvo = alvo.transform.position; // Posição do alvo
            float distancia = Vector3.Distance(transform.position, posicaoAlvo); // Calcula a distância entre a câmera e o alvo

            if (distancia > disMax) // Se a distância for maior que a distância máxima permitida
            {
                Vector3 direcao = (posicaoAlvo - transform.position).normalized; // Calcula a direção do movimento
                posicaoAlvo = transform.position + direcao * disMax; // Ajusta a posição desejada para estar dentro da distância máxima
            }

            Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoAlvo, vSuave); // Suaviza a posição da câmera
            transform.position = new Vector3(posicaoSuavizada.x, transform.position.y, transform.position.z); // Atualiza a posição da câmera, mantendo o valor original dos eixos y e z
            vida.transform.position = transform.position + (new Vector3(-7, 4, 0)); // Atualiza a posição do objeto vida
        }
    }

    void MoverCameraYZero()
    {
        Vector3 posicaoDesejada = new Vector3(transform.position.x, 0, transform.position.z); // Posição desejada com y = 0
        Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoDesejada, vSuave); // Suaviza a posição da câmera
        transform.position = posicaoSuavizada; // Atualiza a posição da câmera
        if (Mathf.Abs(transform.position.y) < 0.1f)
        {
            vida.SetActive(true); // Ativa o objeto Vida
        }
    }
}