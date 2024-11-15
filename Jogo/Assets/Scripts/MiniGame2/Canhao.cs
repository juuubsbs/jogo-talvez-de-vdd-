using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab da bala
    public float forcaTiro = 10f; // Força do tiro

    // Update é chamado uma vez por frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi clicado
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        // Converte a posição do mouse para a posição no mundo
        Vector3 posicaoMouse = Input.mousePosition;
        posicaoMouse.z = Camera.main.nearClipPlane;
        Vector3 posicaoMundo = Camera.main.ScreenToWorldPoint(posicaoMouse);
        // Calcula a direção do tiro
        Vector3 direcaoTiro = (posicaoMundo - transform.position).normalized;
        // Instancia a bala
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        // Aplica uma força na bala na direção do tiro
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(direcaoTiro * forcaTiro, ForceMode2D.Impulse);
    }
}