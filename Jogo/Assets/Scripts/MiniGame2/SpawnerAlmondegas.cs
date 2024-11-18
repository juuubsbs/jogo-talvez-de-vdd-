using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAlmondegas : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Prefab a ser spawnado
    [SerializeField] private float intervaloMin = 0.5f; // Intervalo mínimo de tempo entre spawns
    [SerializeField] private float intervaloMax = 3f; // Intervalo máximo de tempo entre spawns

    private float tempoDesdeUltimoSpawn; // Tempo desde o último spawn
    private float intervaloSpawn; // Intervalo de tempo para o próximo spawn

    // Array de modos de spawn: 0 = Esquerda, 1 = Direita, 2 = Ambos
    private int[] modosDeSpawn;
    public int modo; // Modo de spawn atual

    void Start()
    {
        tempoDesdeUltimoSpawn = 0f; // Inicializa o tempo desde o último spawn
        modo = 0; // Define o modo de spawn inicial
        intervaloSpawn = Random.Range(intervaloMin, intervaloMax); // Define o intervalo de spawn inicial aleatório
    }

    void Update()
    {
        tempoDesdeUltimoSpawn += Time.deltaTime; // Incrementa o tempo desde o último spawn

        if (tempoDesdeUltimoSpawn >= intervaloSpawn)
        {
            SpawnPrefab(modo); // Chama o método de spawn
            tempoDesdeUltimoSpawn = 0f; // Reseta o tempo desde o último spawn
            intervaloSpawn = Random.Range(intervaloMin, intervaloMax); // Define o próximo intervalo de spawn aleatório
        }
    }

    void SpawnPrefab(int modo)
    {
        switch (modo)
        {
            case 0: // Esquerda
                SpawnNaEsquerda();
                break;
            case 1: // Direita
                SpawnNaDireita();
                break;
            case 2: // Ambos
                SpawnNaEsquerda();
                SpawnNaDireita();
                break;
        }
    }

    void SpawnNaEsquerda()
    {
        float x = Random.Range(-28f, -26f); // Gera uma posição x aleatória à esquerda
        float y = Random.Range(-4f, 4f); // Gera uma posição y aleatória
        Vector3 posicaoSpawn = new Vector3(x, y, 0f); // Cria o vetor de posição para o spawn

        GameObject novoPrefab = Instantiate(prefab, posicaoSpawn, Quaternion.identity, transform); // Instancia o prefab na posição gerada

        // Define uma escala aleatória para o objeto spawnado
        float escalaAleatoria = Random.Range(0.2f, 1f);
        novoPrefab.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria); // Aplica a escala ao objeto
        Inimigo inimigo = novoPrefab.GetComponent<Inimigo>(); // Obtém o componente Inimigo do objeto
        inimigo.hitsToDeath = Mathf.RoundToInt(Mathf.Lerp(2, 8, (escalaAleatoria - 0.2f) / 0.8f)); // Define o número de acertos necessários para destruir o inimigo com base na escala
    }

    void SpawnNaDireita()
    {
        float x = Random.Range(26f, 28f); // Gera uma posição x aleatória à direita
        float y = Random.Range(-4f, 4f); // Gera uma posição y aleatória
        Vector3 posicaoSpawn = new Vector3(x, y, 0f); // Cria o vetor de posição para o spawn

        GameObject novoPrefab = Instantiate(prefab, posicaoSpawn, Quaternion.identity, transform); // Instancia o prefab na posição gerada

        // Define uma escala aleatória para o objeto spawnado
        float escalaAleatoria = Random.Range(0.2f, 1f);
        novoPrefab.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria); // Aplica a escala ao objeto
        Inimigo inimigo = novoPrefab.GetComponent<Inimigo>(); // Obtém o componente Inimigo do objeto
        inimigo.hitsToDeath = Mathf.RoundToInt(Mathf.Lerp(2, 8, (escalaAleatoria - 0.2f) / 0.8f)); // Define o número de acertos necessários para destruir o inimigo com base na escala
    }
}