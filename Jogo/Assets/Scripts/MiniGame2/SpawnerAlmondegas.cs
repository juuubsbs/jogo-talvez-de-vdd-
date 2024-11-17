using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAlmondegas : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Prefab a ser spawnado
    [SerializeField] private float intervaloMin = 0.5f; // Intervalo mínimo de tempo entre spawns
    [SerializeField] private float intervaloMax = 3f; // Intervalo máximo de tempo entre spawns

    private float tempoDesdeUltimoSpawn;
    private float intervaloSpawn;

    // Array de modos de spawn: 0 = Esquerda, 1 = Direita, 2 = Ambos
    private int[] modosDeSpawn;
    public int modo;

    void Start()
    {
        tempoDesdeUltimoSpawn = 0f; // Inicializa o tempo desde o último spawn
        modo = 0; // Define o modo de spawn inicial
    }

    void Update()
    {
        intervaloSpawn = Random.Range(intervaloMin, intervaloMax);

        tempoDesdeUltimoSpawn += Time.deltaTime;

        if (tempoDesdeUltimoSpawn >= intervaloSpawn)
        {
            SpawnPrefab(modo);
            tempoDesdeUltimoSpawn = 0f;
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
        float x = Random.Range(-28f, -26f);
        float y = Random.Range(-4f, 4f);
        Vector3 posicaoSpawn = new Vector3(x, y, 0f);

        GameObject novoPrefab = Instantiate(prefab, posicaoSpawn, Quaternion.identity);

        // Define uma escala aleatória para o objeto spawnado
        float escalaAleatoria = Random.Range(0.5f, 2f);
        novoPrefab.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);
    }

    void SpawnNaDireita()
    {
        float x = Random.Range(26f, 28f);
        float y = Random.Range(-4f, 4f);
        Vector3 posicaoSpawn = new Vector3(x, y, 0f);

        GameObject novoPrefab = Instantiate(prefab, posicaoSpawn, Quaternion.identity);

        // Define uma escala aleatória para o objeto spawnado
        float escalaAleatoria = Random.Range(0.5f, 2f);
        novoPrefab.transform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, escalaAleatoria);
    }
}