using UnityEngine;

public class GerenciadorDeJogo : MonoBehaviour
{
    public bool jogoIniciou = false;
    public GameObject vida;
    public GameObject princesaObject;
    public GameObject spawnerObject;
    public GameObject mrPasta;
    private Princesa princesaScript;
    private int fase1;
    private int fase2;
    private SpawnerAlmondegas spawnerScript;


    void Start()
    {
        fase1 = Random.Range(5, 10);
        fase2 = Random.Range(15, 20);
        princesaScript = princesaObject.GetComponent<Princesa>();
        spawnerScript = spawnerObject.GetComponent<SpawnerAlmondegas>();
    }

    void Update()
    {
        ativaVida();

        if (princesaScript.kills >= fase1)
        {
            spawnerScript.modo = 1;
        }
        else if (princesaScript.kills >= fase2)
        {
            spawnerScript.modo = 2;
        }
    }

    void ativaVida()
    {
        if (vida != null && Mathf.Abs(vida.transform.position.y) < 0.1f)
        {
            vida.SetActive(true); // Ativa o objeto Vida
        }
    }
}