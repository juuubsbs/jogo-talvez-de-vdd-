using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princesa : MonoBehaviour
{
    public float velocidadeHorizontal = 5f; // Velocidade de movimentação horizontal
    public float velocidadeVertical = 3f; // Velocidade de movimentação vertical
    private float limiteYMin = -2f; // Limite mínimo do eixo Y
    private float limiteYMax = 3.5f; // Limite máximo do eixo Y
    private float limiteXMin = -16f; // Limite mínimo do eixo X
    private float limiteXMax = 16f; // Limite máximo do eixo X

    // Update é chamado uma vez por frame
    void Update()
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

        // Calcula a nova posição
        Vector3 novaPosicao = transform.position + new Vector3(movimentoHorizontal * velocidadeHorizontal, movimentoVertical * velocidadeVertical, 0) * Time.deltaTime;

        // Limita a posição dentro dos limites especificados
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteXMin, limiteXMax);
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, limiteYMin, limiteYMax);

        // Atualiza a posição do personagem
        transform.position = novaPosicao;
    }
}