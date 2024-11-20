using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject prefabBala; // Prefab da bala a ser instanciada
    public float forcaDoTiro = 10f; // Força aplicada ao disparar a bala
    public GameObject balaSpawnerEsquerda; // Referência ao objeto que irá instanciar a bala
    public GameObject balaSpawnerDireita; // Referência ao objeto que irá instanciar a bala
    public GameObject canhaoEsquerdo; // Referência ao canhão esquerdo
    public GameObject canhaoDireito; // Referência ao canhão direitoa
    void Update()
    {
        // Obtém a posição do mouse em coordenadas do mundo
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Obtém a posição do gerenciador de canhões
        Vector3 posicaoGerenciador = transform.position;

        // Calcula a posição do mouse relativa ao gerenciador de canhões
        Vector3 posicaoRelativaMouse = posicaoMouse - posicaoGerenciador;

        // Canhão direito - Só deve rotacionar quando o mouse está à direita (x > 0)
        if (canhaoDireito != null && posicaoRelativaMouse.x > 0)
        {
            Vector2 direcaoDireita = canhaoDireito.transform.position - posicaoMouse; // Inverte a direção
            float anguloDireita = Mathf.Atan2(direcaoDireita.y, direcaoDireita.x) * Mathf.Rad2Deg;

            // Ajusta o ângulo para garantir que fique dentro do intervalo de 90 a 210 graus
            if (anguloDireita < 0)
            {
                anguloDireita += 360f;
            }
            Debug.Log($"Posição Mouse: {posicaoMouse}, Direção Direita: {direcaoDireita}, Ângulo Direita: {anguloDireita}");

            float anguloLimitadoDireita = Mathf.Clamp(anguloDireita, 90f, 210f);
            canhaoDireito.transform.rotation = Quaternion.Euler(0, 0, anguloLimitadoDireita);
        }

        // Canhão esquerdo - Só deve rotacionar quando o mouse está à esquerda (x < 0)
        if (canhaoEsquerdo != null && posicaoRelativaMouse.x < 0)
        {
            Vector2 direcaoEsquerda = posicaoMouse - canhaoEsquerdo.transform.position; // Direção correta
            float anguloEsquerda = Mathf.Atan2(direcaoEsquerda.y, direcaoEsquerda.x) * Mathf.Rad2Deg;
            Debug.Log($"Posição Mouse: {posicaoMouse}, Direção Esquerda: {direcaoEsquerda}, Ângulo Esquerda: {anguloEsquerda}");
            // Limita o ângulo do canhão esquerdo no intervalo de 150° a 270°

            if (anguloEsquerda < 0)
            {
                anguloEsquerda += 360f;
            }
            float anguloLimitadoEsquerda = Mathf.Clamp(anguloEsquerda, 150f, 320f);
            anguloLimitadoEsquerda = anguloLimitadoEsquerda - 180f;
            canhaoEsquerdo.transform.rotation = Quaternion.Euler(0, 0, anguloLimitadoEsquerda);
        }

        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            Atirar(posicaoRelativaMouse, posicaoMouse);
        }




    }

    void Atirar(Vector3 posicaoRelativaMouse, Vector3 posicaoMouse)
    {
        // Seleciona o canhão com base na posição x do mouse
        GameObject canhaoSelecionado;
        GameObject balaSpawnerSelecionado;
        if (posicaoRelativaMouse.x < 0)
        {
            canhaoSelecionado = canhaoEsquerdo;
            balaSpawnerSelecionado = balaSpawnerEsquerda;
        }
        else
        {
            canhaoSelecionado = canhaoDireito;
            balaSpawnerSelecionado = balaSpawnerDireita;
        }

        if (canhaoSelecionado != null)
        {
            // Instancia a bala no spawner do canhão selecionado
            GameObject bala = Instantiate(prefabBala, balaSpawnerSelecionado.transform.position, canhaoSelecionado.transform.rotation);
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