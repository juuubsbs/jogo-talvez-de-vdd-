using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class callScene : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChamaCena);
    }

    void ChamaCena(){
        SceneManager.LoadScene("MiniGame1");
        SceneManager.UnloadSceneAsync("MiniGame1");
    }
}
