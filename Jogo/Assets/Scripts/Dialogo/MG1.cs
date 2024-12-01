using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MG1 : MonoBehaviour
{
    public string[] dialogoStr; // Array de strings que armazena o diálogo
    public GameObject textoObj; // Objeto que exibe o diálogo
    public GameObject gerenciadorObj;
    private Text texto; // Texto que exibe o diálogo
    public int index; // Índice da fala atual
    private bool primeiroDialogo = false;
    private bool dialogoFinalIniciado = false;

    private GerenciadorDeJogoMG1 gerenciadorScript; // Referência ao script GerenciadorDeJogoMG1


    // Start is called before the first frame update
    void Start()
    {
        gerenciadorScript = gerenciadorObj.GetComponent<GerenciadorDeJogoMG1>(); // Obtém o script GerenciadorDeJogoMG1
        texto = textoObj.GetComponent<Text>(); // Obtém o componente Text do objeto
    }

    // Update is called once per frame
    void Update()
    {
        if (!gerenciadorScript.jogoAcabou)
        {
            chamaPrimeiroDialogo();
        }
        else if (gerenciadorScript.jogoAcabou && !dialogoFinalIniciado)
        {
            chamaDialogoFinal();
        } else if(gerenciadorScript.jogoAcabou && dialogoFinalIniciado && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && texto.text == dialogoStr[index])
        {
            gerenciadorScript.fimDaMensagem = true;
        }
    }

    void chamaPrimeiroDialogo()
    {
        if (primeiroDialogo == false)
        {
            StartCoroutine(Dialogo());
            primeiroDialogo = true;
        }

        if (texto.text == dialogoStr[index])
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Verifica se o jogador pressionou a tecla de espaço ou o botão do mouse
            {
                index++; // Incrementa o índice
                texto.text = ""; // Limpa o texto
                if (index < dialogoStr.Length) // Verifica se ainda há mais diálogos
                {
                    StartCoroutine(Dialogo()); // Inicia a rotina de exibição do diálogo
                }
            }
            VerificaFimDialogo();
        }
    }

void chamaDialogoFinal()
{
    if (!dialogoFinalIniciado && index == 3) // Inicia o diálogo final apenas uma vez
    {
        texto.text = ""; // Limpa o texto para começar o diálogo
        dialogoFinalIniciado = true; // Marca que o diálogo final começou
        StartCoroutine(Dialogo()); // Inicia a rotina do diálogo
    }
}


void VerificaFimDialogo()
{
    if (index == 3 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) // Verifica se o índice é igual a 3
    {
        gameObject.SetActive(false); // Desativa o objeto
        gerenciadorScript.jogoIniciou = true; // Define a variável jogoIniciou como verdadeira
    }
}


    IEnumerator Dialogo()
    {
        texto.text = ""; // Garante que o texto esteja vazio no início
        foreach (char letter in dialogoStr[index])
        {
            texto.text += letter; // Adiciona cada letra ao texto
            yield return new WaitForSeconds(0.025f); // Controla o tempo entre cada letra
        }

        // Aguarde até que o texto esteja completamente exibido antes de permitir avançar
        yield return null;
    }
}
