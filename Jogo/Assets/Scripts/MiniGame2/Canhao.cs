using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject prefabBala; // Prefab da bala a ser instanciada
    public float forcaDoTiro = 10f; // Força aplicada ao disparar a bala
    public GameObject canhaoEsquerdo; // Referência ao canhão esquerdo
    public GameObject canhaoDireito; // Referência ao canhão direito

    void Update()
    {
        // Obtém a posição do mouse em coordenadas do mundo
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Canhão direito - Só deve rotacionar quando o mouse está à direita (x > 0)
        if (canhaoDireito != null && posicaoMouse.x > 0)
        {
            Vector2 direcaoDireita = canhaoDireito.transform.position - posicaoMouse; // Inverte a direção
            float anguloDireita = Mathf.Atan2(direcaoDireita.y, direcaoDireita.x) * Mathf.Rad2Deg;

            // Ajusta o ângulo para garantir que fique dentro do intervalo de 90 a 210 graus
            if (anguloDireita < 0)
            {
                anguloDireita += 360f;
            }

            float anguloLimitadoDireita = Mathf.Clamp(anguloDireita, 90f, 210f);
            canhaoDireito.transform.rotation = Quaternion.Euler(0, 0, anguloLimitadoDireita);
        }

        // Canhão esquerdo - Só deve rotacionar quando o mouse está à esquerda (x < 0)
        if (canhaoEsquerdo != null && posicaoMouse.x < 0)
        {
            Vector2 direcaoEsquerda = canhaoEsquerdo.transform.position - posicaoMouse; // Inverte a direção
            float anguloEsquerda = Mathf.Atan2(direcaoEsquerda.y, direcaoEsquerda.x) * Mathf.Rad2Deg;
            float anguloLimitadoEsquerda = Mathf.Clamp(anguloEsquerda, -30f, 90f);
            canhaoEsquerdo.transform.rotation = Quaternion.Euler(0, 0, anguloLimitadoEsquerda);
        }

        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            Atirar(posicaoMouse);
        }
    }

    void Atirar(Vector3 posicaoMouse)
    {
        // Seleciona o canhão com base na posição x do mouse
        GameObject canhaoSelecionado;
        if (posicaoMouse.x < 0)
        {
            canhaoSelecionado = canhaoEsquerdo;
        }
        else
        {
            canhaoSelecionado = canhaoDireito;
        }

        if (canhaoSelecionado != null)
        {
            // Instancia a bala na posição e rotação do canhão selecionado
            GameObject bala = Instantiate(prefabBala, canhaoSelecionado.transform.position, canhaoSelecionado.transform.rotation);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Direção do mouse em relação ao canhão
                Vector2 direcaoDisparo = (posicaoMouse - canhaoSelecionado.transform.position).normalized;

                // Aplica a força na direção calculada
                rb.AddForce(direcaoDisparo * forcaDoTiro, ForceMode2D.Impulse);
            }
        }
    }
}