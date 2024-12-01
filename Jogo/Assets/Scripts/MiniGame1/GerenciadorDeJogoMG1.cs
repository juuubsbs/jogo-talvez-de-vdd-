using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GerenciadorDeJogoMG1 : MonoBehaviour
{
    public bool jogoIniciou = false;
    public GameObject vida;
    public GameObject princesa;
    public GameObject dialog;
    public GameObject spawner;
    public GameObject mrPasta;
    public GameObject pauseCanvas;
    public float totalHits;
    public bool jogoAcabou = false;
    public bool fimDaMensagem = false;
    private float tempoDecorrido = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (jogoIniciou)
        {
            pauseCanvas.SetActive(true);
            vida.SetActive(true);
            princesa.SetActive(true);
            mrPasta.SetActive(true);
            if (!jogoAcabou)
            {
                StartCoroutine(espera2segundosEAtivaSpawner());
            }

            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido >= 25f)
            {
                DestruirTodosOsFilhos(spawner);
                jogoAcabou = true;
                spawner.SetActive(false);
                vida.SetActive(false);
                princesa.SetActive(false);
                mrPasta.SetActive(false);
                dialog.SetActive(true);
                if (fimDaMensagem)
                {
                    StartCoroutine(esperaECarregaNextFase());
                }
            }
        }
    }

    IEnumerator esperaECarregaNextFase()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MiniGame2");
    }
    IEnumerator espera2segundosEAtivaSpawner()
    {
        yield return new WaitForSeconds(2f);
        spawner.SetActive(true);
    }
    void DestruirTodosOsFilhos(GameObject objeto)
    {
        foreach (Transform child in objeto.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
