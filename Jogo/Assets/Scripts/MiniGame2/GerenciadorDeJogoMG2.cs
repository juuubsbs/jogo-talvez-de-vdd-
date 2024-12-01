using UnityEngine;

public class GerenciadorDeJogoMG2 : MonoBehaviour
{
    public bool jogoIniciou = false;
    public GameObject vida;
    public GameObject princesaObject;
    public GameObject spawnerObject;
    public GameObject pauseCanvas;
    public GameObject dialogo;
    private Princesa princesaScript;
    private int fase1;
    private int fase2;
    private int vitoria;
    private SpawnerAlmondegas spawnerScript;
    public bool fimDaMensagem1 = false;
    public bool fimDaMensagem2 = false;

    public bool jogoAcabou = false;


    void Start()
    {
        fase1 = Random.Range(5, 10);
        fase2 = 15;
        vitoria = 20;
        princesaScript = princesaObject.GetComponent<Princesa>();
        spawnerScript = spawnerObject.GetComponent<SpawnerAlmondegas>();
    }

    void Update()
    {
        princesaObject.SetActive(jogoIniciou);
        spawnerObject.SetActive(jogoIniciou);

        if (princesaScript.kills == fase1)
        {
            spawnerScript.modo = 1;
        }
        else if (princesaScript.kills == fase2)
        {
            spawnerScript.modo = 2;
        }
        else if (princesaScript.kills >= vitoria)
        {
            spawnerObject.SetActive(false);
            princesaObject.SetActive(false);
            vida.SetActive(false);
            pauseCanvas.SetActive(false);  
            jogoAcabou = true;
            dialogo.SetActive(true);
        }
        if (princesaScript.kills >= vitoria && fimDaMensagem2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Vitoria");
        }
    }
}