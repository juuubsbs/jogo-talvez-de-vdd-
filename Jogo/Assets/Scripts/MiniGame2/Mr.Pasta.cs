using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrPasta : MonoBehaviour
{
    public float amplitude = 5f; // Amplitude do movimento
    private GerenciadorDeJogoMG1 gerenciadorScript; // Referência ao script GerenciadorDeJogoMG1
    public float frequencia = 1f; // Frequência do movimento
    private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        tempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gerenciadorScript = GameObject.Find("GerenciadorDeJogo").GetComponent<GerenciadorDeJogoMG1>(); //pega o script do gerenciador
        if(gerenciadorScript.jogoIniciou) // Verifica se a variável jogoIniciou é verdadeira
        {
            gameObject.SetActive(true);
            MovimentoOnda(); // Chama a função MovimentoOnda a cada frame
        }
    }

    void MovimentoOnda()
        {
         tempo += Time.deltaTime - 0.001f; // Incrementa o tempo

        // Calcula a posição usando funções trigonométricas
        float x = amplitude * Mathf.Sin(frequencia * tempo);  
        float y = amplitude * Mathf.Sin(frequencia * tempo) * Mathf.Cos(frequencia * tempo);

        // Aplica a nova posição ao objeto
        transform.position = new Vector3(x, y, transform.position.z);
        }
}