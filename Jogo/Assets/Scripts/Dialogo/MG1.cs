using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MG1 : MonoBehaviour
{
    public string[] dialogo; // Array de strings que armazena o diálogo
    public Text texto; // Texto que exibe o diálogo
    private GerenciadorDeJogoMG1 gerenciadorScript; // Referência ao script GerenciadorDeJogoMG1
    private int index; // Índice da fala atual

    // Start is called before the first frame update
    void Start()
    {
        gerenciadorScript = GameObject.Find("GerenciadorDeJogo").GetComponent<GerenciadorDeJogoMG1>(); //pega o script do gerenciador

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Dialogo()
    {
        foreach (string fala in dialogo)
        {
            texto.text = fala; // Exibe a fala atual
            yield return new WaitForSeconds(2); // Aguarda 2 segundos
        }
        SceneManager.LoadScene("MiniGame1"); // Carrega a cena do minigame 1
    }
}
