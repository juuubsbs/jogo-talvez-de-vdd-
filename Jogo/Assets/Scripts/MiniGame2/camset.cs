using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camset : MonoBehaviour
{
    public GameObject alvo; // Referência ao objeto alvo
    public float vSuave = 0.025f; // Velocidade de suavização
    public float disMax = 5f; // Distância máxima para a câmera seguir

    // Update é chamado uma vez por frame
    void Update()
    {
        Follow(); // Chama a função Follow a cada frame
    }

    void Follow()
    {
        if (alvo != null) // Verifica se o alvo não é nulo
        {
            Vector3 posicaoAlvo = alvo.transform.position; // Posição do alvo
            float distancia = Vector3.Distance(transform.position, posicaoAlvo); // Calcula a distância entre a câmera e o alvo

            if (distancia > disMax) // Se a distância for maior que a distância máxima permitida
            {
                Vector3 direcao = (posicaoAlvo - transform.position).normalized; // Calcula a direção do movimento
                posicaoAlvo = transform.position + direcao * disMax; // Ajusta a posição desejada para estar dentro da distância máxima
            }

            Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoAlvo, vSuave); // Suaviza a posição da câmera
            transform.position = new Vector3(posicaoSuavizada.x, posicaoSuavizada.y, transform.position.z); // Atualiza a posição da câmera, mantendo o valor original do eixo z
        }
    }
}