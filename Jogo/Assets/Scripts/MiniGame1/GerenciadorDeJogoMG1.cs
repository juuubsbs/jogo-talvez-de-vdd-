using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogoMG1 : MonoBehaviour
{
    public bool jogoIniciou = false;
    public GameObject vida;
    public GameObject princesa;
    public GameObject dialog;
    public GameObject mrPasta;
    public float totalHits;
    private float tempoDecorrido = 0f;

    void Start()
    {

    }

    void Update()
    {
        if(jogoIniciou)
        {
            vida.SetActive(true);
            princesa.SetActive(true);
            mrPasta.SetActive(true);
        }

        tempoDecorrido += Time.deltaTime;
        if (tempoDecorrido >= 30f)
        {
            SceneManager.LoadScene("MiniGame2");
        }
    }
}